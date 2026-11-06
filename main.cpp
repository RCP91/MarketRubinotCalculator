#define NOMINMAX
#include <windows.h>
#include <commctrl.h>
#include <vector>
#include <string>
#include <sstream>
#include <fstream>
#include <algorithm>
#include <map>
#include <cstdio>
#include <cstdlib>

#pragma comment(lib, "comctl32.lib")
#pragma comment(lib, "user32.lib")
#pragma comment(lib, "gdi32.lib")

#define ID_OFFERNAME 1001
#define ID_BALANCE 1002
#define ID_SELL 1003
#define ID_BUY 1004
#define ID_AMOUNT 1005
#define ID_TAX 1006
#define ID_BTN_SELL 1007
#define ID_BTN_BUY 1008
#define ID_BTN_DONE 1009
#define ID_BTN_CANCEL 1010
#define ID_LIST 1011

#define ID_LBL_SELLTOTAL 2001
#define ID_LBL_BUYTOTAL 2002
#define ID_LBL_FEESELL 2003
#define ID_LBL_FEEBUY 2004
#define ID_LBL_FEEALL 2005
#define ID_LBL_SELLFINAL 2006
#define ID_LBL_BUYFINAL 2007
#define ID_LBL_PROFIT 2008
#define ID_LBL_PROFITNPC 2009
#define ID_LBL_PROFITPERCENT 2010
#define ID_LBL_DISPLAY 2011

struct Offer {
    std::string time;
    int type;
    std::string name;
    long long amount;
    long long buy;
    long long sell;
    int status;
    int tax;
};

static std::vector<Offer> offers;
static long long balance = 0;
static int taxPercent = 2;
static const char* lastSaveReason = "none";
static bool initializing = true;
static bool formatting = false;

static HWND hOfferName, hBalance, hSell, hBuy, hAmount, hTax;
static HWND hSellTotal, hBuyTotal, hFeeSell, hFeeBuy, hFeeAll, hSellFinal, hBuyFinal, hProfit, hProfitNpc, hProfitPercent, hDisplay;
static HWND hList;
static HWND hBtnSell, hBtnBuy, hBtnCancel, hBtnDone;


std::string GetConfigPath() {

    char buf[MAX_PATH];
    GetModuleFileNameA(NULL, buf, MAX_PATH);
    std::string p = buf;
    size_t pos = p.find_last_of("\\/");
    if (pos != std::string::npos) p = p.substr(0, pos + 1);
    return p + "config.txt";
}

// 1234567 -> 1.234.567
static std::string FmtInt(long long v) {

    std::string s = std::to_string(v < 0 ? -v : v);
    for (int i = (int)s.size() - 3; i > 0; i -= 3) s.insert(i, ".");
    return (v < 0 ? "-" : "") + s;
}

long long GetInt(HWND h) {

    char buf[128];
    GetWindowTextA(h, buf, 128);
    std::string digits;
    for (char* p = buf; *p; ++p) {
        if (*p >= '0' && *p <= '9') digits += *p;
        else if (*p == '-' && digits.empty()) digits += *p;
    }
    if (digits.empty() || digits == "-") return 0;
    return atoll(digits.c_str());
}

std::string GetText(HWND h) {

    char buf[256];
    GetWindowTextA(h, buf, 256);
    return std::string(buf);
}
void SetText(HWND h, const std::string& s) {
    SetWindowTextA(h, s.c_str());
}
long long CalculateFee(long long price, int percent) {

    if (price <= 0) return 0;
    long long fee = (long long)(price * (percent / 100.0));
    if (fee < 20) fee = 20;
    //if (fee > 1000000) fee = 1000000;
    return fee;
}
std::string StatusText(int t) {

    if (t == 0) return "Canceled";
    if (t == 1) return "Sold";
    if (t == 2) return "Buy";
    return "Pending";
}
std::string OfferTypeText(int t) {

    if (t == 1) return "Sell";
    if (t == 2) return "Buy";
    return "Unknow";
}

void SaveConfig() {

    std::ofstream f(GetConfigPath());
    f << "BALANCE " << balance << "\n";
    f << "TAX " << taxPercent << "\n";
    f << "OFFERS " << offers.size() << "\n";
    for (auto& o : offers) {
        f << o.time << "|" << o.type << "|" << o.name << "|" << o.amount << "|" << o.buy << "|" << o.sell << "|" << o.status << "|" << o.tax << "\n";
    }
    f.close();
}
void LoadConfig() {

    std::ifstream f(GetConfigPath());
    if (!f.is_open()) return;
    std::string key;
    while (f >> key) {

        if (key == "BALANCE") { f >> balance; }
        else if (key == "TAX") { f >> taxPercent; }
        else if (key == "OFFERS") {
            int n; f >> n; std::string dummy; std::getline(f, dummy);
            offers.clear();

            for (int i = 0; i < n; i++) {
                std::string line;
                std::getline(f, line);
                if (line.empty()) continue;
                std::stringstream ss(line);
                std::string tok;
                Offer o;
                std::getline(ss, o.time, '|');
                std::getline(ss, tok, '|'); o.type = atoi(tok.c_str());
                std::getline(ss, o.name, '|');
                std::getline(ss, tok, '|'); o.amount = atoll(tok.c_str());
                std::getline(ss, tok, '|'); o.buy = atoll(tok.c_str());
                std::getline(ss, tok, '|'); o.sell = atoll(tok.c_str());
                std::getline(ss, tok, '|'); o.status = atoi(tok.c_str());
                if (std::getline(ss, tok, '|')) o.tax = atoi(tok.c_str()); else o.tax = 2;
                if (o.tax <= 0) o.tax = 2;
                offers.push_back(o);
            }
        }
        else {
            std::string rest; std::getline(f, rest);
        }
    }
    f.close();
}

void RefreshList() {

    SendMessageA(hList, LB_RESETCONTENT, 0, 0);
    for (auto& o : offers) {
        long long price = (o.type == 1) ? o.sell : o.buy;
        std::ostringstream ss;
        ss << o.time << " | " << OfferTypeText(o.type) << " | " << o.name << " | " << o.amount << " | " << price << " | " << StatusText(o.status);
        SendMessageA(hList, LB_ADDSTRING, 0, (LPARAM)ss.str().c_str());
    }
}

void GetCalculate() {

    std::string name = GetText(hOfferName);
    long long sell = GetInt(hSell);
    long long buy = GetInt(hBuy);
    long long amount = GetInt(hAmount);
    if (amount <= 0) amount = 1;
    long long tax = GetInt(hTax);
    if (tax < 0) tax = 0;
    taxPercent = (int)tax;

    long long totalBuy = buy * amount;
    long long totalSell = sell * amount;

    long long feeBuy = CalculateFee(totalBuy, taxPercent);
    long long feeSell = CalculateFee(totalSell, taxPercent);
    long long feeAll = feeBuy + feeSell;
    long long profitAll = totalSell - feeSell - totalBuy - feeBuy;

    char buf[128];
    SetText(hSellTotal, FmtInt(totalSell));
    SetText(hBuyTotal, FmtInt(totalBuy));
    SetText(hFeeSell, FmtInt(-feeSell));
    SetText(hFeeBuy, FmtInt(-feeBuy));
    SetText(hFeeAll, FmtInt(-feeAll));

    long long profit = (sell > 0) ? totalSell - feeSell : totalBuy + feeBuy;
    SetText(hSellFinal, FmtInt(profit));
    SetText(hBuyFinal, FmtInt(totalBuy + feeBuy));

    SetText(hProfit, FmtInt(profitAll));

    SetText(hProfitNpc, FmtInt(profitAll + feeSell));

    double profitPercent = (totalSell > 0) ? (double)(totalSell - totalBuy - feeAll) / totalSell * 100.0 : 0.0;
    double riskPercent = (totalSell > 0) ? (double)(totalBuy + feeAll) / totalSell * 100.0 : 0.0;
    long long buyAtt = (profitAll > 0 && feeBuy > 0) ? profitAll / feeBuy : 0;
    long long sellAtt = (profitAll > 0 && feeSell > 0) ? profitAll / feeSell : 0;

    char buf2[256];
    sprintf(buf2, "%.2f%%", profitPercent);
    SetText(hProfitPercent, buf2);

    sprintf(buf2, "Risk: %.2f%% / Attempts Buy: %lld / Attempts Sell: %lld", (riskPercent > 100 ? 100.0 : riskPercent), buyAtt, sellAtt);
    SetText(hDisplay, buf2);
}

void UpdateBalanceEdit() {
    SetText(hBalance, FmtInt(balance));
}

static const COLORREF C_BG = RGB(22, 24, 32);
static const COLORREF C_PANEL = RGB(33, 37, 50);
static const COLORREF C_PANEL2 = RGB(38, 43, 58);
static const COLORREF C_EDIT = RGB(45, 50, 68);
static const COLORREF C_BORDER = RGB(62, 69, 94);
static const COLORREF C_SELECT = RGB(52, 70, 115);
static const COLORREF C_TEXT = RGB(232, 234, 242);
static const COLORREF C_MUTED = RGB(140, 148, 172);
static const COLORREF C_ACCENT = RGB(96, 150, 255);
static const COLORREF C_GREEN = RGB(76, 217, 130);
static const COLORREF C_RED = RGB(255, 99, 110);
static const COLORREF C_AMBER = RGB(255, 193, 80);

static HBRUSH brBg, brPanel, brEdit;
static HFONT fNormal, fSmall, fBold, fMid, fBig;

static std::vector<RECT> panels;
static std::vector<RECT> editBoxes;
static std::vector<RECT> separators;
static std::map<HWND, COLORREF> labelColor;

// col list weight
static const int COL_TIME = 8, COL_TIME_W = 62;
static const int COL_TYPE = 72, COL_TYPE_W = 40;
static const int COL_NAME = 116, COL_NAME_W = 108;
static const int COL_QTY = 228, COL_QTY_W = 40;
static const int COL_PRICE = 272, COL_PRICE_W = 80;
static const int COL_STAT = 358, COL_STAT_W = 52;

static HFONT MakeFont(int h, int weight, const char* face) {

    return CreateFontA(h, 0, 0, 0, weight, FALSE, FALSE, FALSE, DEFAULT_CHARSET,
        OUT_DEFAULT_PRECIS, CLIP_DEFAULT_PRECIS, CLEARTYPE_QUALITY,
        DEFAULT_PITCH | FF_DONTCARE, face);
}

static COLORREF Shade(COLORREF c, int pct) {

    int r = std::min(255, GetRValue(c) * pct / 100);
    int g = std::min(255, GetGValue(c) * pct / 100);
    int b = std::min(255, GetBValue(c) * pct / 100);
    return RGB(r, g, b);
}


static HWND MakeLabel(HWND p, const char* text, int x, int y, int w, int h, HFONT f, DWORD style = 0, COLORREF color = 0, bool hasColor = false, int id = 0) {

    HWND c = CreateWindowExA(0, "STATIC", text, WS_CHILD | WS_VISIBLE | SS_CENTERIMAGE | style,
        x, y, w, h, p, (HMENU)(INT_PTR)id, NULL, NULL);
    SendMessageA(c, WM_SETFONT, (WPARAM)f, TRUE);
    if (hasColor) labelColor[c] = color;
    return c;
}

static HWND MakeEdit(HWND p, const char* text, int x, int y, int w, int boxH, int id, HFONT f, int editH) {

    RECT r = { x, y, x + w, y + boxH };
    editBoxes.push_back(r);
    HWND e = CreateWindowExA(0, "EDIT", text, WS_CHILD | WS_VISIBLE | ES_CENTER | ES_AUTOHSCROLL,
        x + 12, y + (boxH - editH) / 2, w - 24, editH, p, (HMENU)(INT_PTR)id, NULL, NULL);
    SendMessageA(e, WM_SETFONT, (WPARAM)f, TRUE);
    return e;
}

static HWND MakeButton(HWND p, const char* text, int x, int y, int w, int h, int id) {

    HWND b = CreateWindowExA(0, "BUTTON", text, WS_CHILD | WS_VISIBLE | BS_OWNERDRAW,
        x, y, w, h, p, (HMENU)(INT_PTR)id, NULL, NULL);
    SendMessageA(b, WM_SETFONT, (WPARAM)fBold, TRUE);
    return b;
}

static void AddPanel(int x, int y, int w, int h) { RECT r = { x, y, x + w, y + h }; panels.push_back(r); }
static void AddSeparator(int x, int y, int w) { RECT r = { x, y, x + w, y + 1 }; separators.push_back(r); }

static bool InsidePanel(HWND parent, HWND child) {

    RECT r; GetWindowRect(child, &r);
    MapWindowPoints(NULL, parent, (LPPOINT)&r, 2);
    POINT c = { (r.left + r.right) / 2, (r.top + r.bottom) / 2 };
    for (auto& p : panels) if (PtInRect(&p, c)) return true;
    return false;
}

static void DrawOfferItem(LPDRAWITEMSTRUCT d) {

    HDC dc = d->hDC;
    RECT r = d->rcItem;

    if ((int)d->itemID < 0 || d->itemID >= offers.size()) { FillRect(dc, &r, brPanel); return; }

    const Offer& o = offers[d->itemID];
    bool sel = (d->itemState & ODS_SELECTED) != 0;

    HBRUSH bg = CreateSolidBrush(sel ? C_SELECT : ((d->itemID % 2) ? C_PANEL2 : C_PANEL));
    FillRect(dc, &r, bg);
    DeleteObject(bg);

    SetBkMode(dc, TRANSPARENT);
    SelectObject(dc, fNormal);

    COLORREF statusCol = (o.status == 1) ? C_GREEN : (o.status == 2) ? C_ACCENT : (o.status == 0) ? C_RED : C_AMBER;
    COLORREF typeCol = (o.type == 1) ? C_GREEN : C_ACCENT;
    long long price = (o.type == 1) ? o.sell : o.buy;

    auto cell = [&](const std::string& t, int x, int w, COLORREF c, UINT fmt) {
        RECT cr = { r.left + x, r.top, r.left + x + w, r.bottom };
        SetTextColor(dc, c);
        DrawTextA(dc, t.c_str(), -1, &cr, DT_SINGLELINE | DT_VCENTER | DT_END_ELLIPSIS | DT_NOPREFIX | fmt);
    };

    cell(o.time, COL_TIME, COL_TIME_W, C_MUTED, DT_LEFT);
    cell(OfferTypeText(o.type), COL_TYPE, COL_TYPE_W, typeCol, DT_LEFT);
    cell(o.name, COL_NAME, COL_NAME_W, C_TEXT, DT_LEFT);
    cell(FmtInt(o.amount), COL_QTY, COL_QTY_W, C_TEXT, DT_RIGHT);
    cell(FmtInt(price), COL_PRICE, COL_PRICE_W, C_TEXT, DT_RIGHT);
    cell(StatusText(o.status), COL_STAT, COL_STAT_W, statusCol, DT_LEFT);
}

static void DrawButton(LPDRAWITEMSTRUCT d) {

    COLORREF base = C_ACCENT;
    switch (d->CtlID) {
        case ID_BTN_SELL:   base = C_GREEN;  break;
        case ID_BTN_BUY:    base = C_ACCENT; break;
        case ID_BTN_CANCEL: base = C_RED;    break;
        case ID_BTN_DONE:   base = C_AMBER;  break;
    }

    bool pressed = (d->itemState & ODS_SELECTED) != 0;
    COLORREF col = pressed ? Shade(base, 75) : base;

    HDC dc = d->hDC;
    FillRect(dc, &d->rcItem, brBg);
    HBRUSH b = CreateSolidBrush(col);
    HPEN pen = CreatePen(PS_SOLID, 1, col);
    HGDIOBJ ob = SelectObject(dc, b), op = SelectObject(dc, pen);
    RoundRect(dc, d->rcItem.left, d->rcItem.top, d->rcItem.right, d->rcItem.bottom, 12, 12);
    SelectObject(dc, ob);
    SelectObject(dc, op);
    DeleteObject(b);
    DeleteObject(pen);

    char txt[64];
    GetWindowTextA(d->hwndItem, txt, 64);
    SetBkMode(dc, TRANSPARENT);
    SetTextColor(dc, RGB(15, 18, 25));
    SelectObject(dc, fBold);
    RECT tr = d->rcItem;

    if (pressed) OffsetRect(&tr, 0, 1);
    DrawTextA(dc, txt, -1, &tr, DT_SINGLELINE | DT_VCENTER | DT_CENTER | DT_NOPREFIX);
}

static void PaintBackground(HWND hwnd) {
    PAINTSTRUCT ps;
    HDC dc = BeginPaint(hwnd, &ps);

    HPEN penBorder = CreatePen(PS_SOLID, 1, C_BORDER);
    HGDIOBJ op = SelectObject(dc, penBorder);

    SelectObject(dc, brPanel);
    for (auto& r : panels) RoundRect(dc, r.left, r.top, r.right, r.bottom, 16, 16);

    SelectObject(dc, brEdit);
    for (auto& r : editBoxes) RoundRect(dc, r.left, r.top, r.right, r.bottom, 10, 10);

    for (auto& r : separators) {
        HBRUSH sb = CreateSolidBrush(C_BORDER);
        FillRect(dc, &r, sb);
        DeleteObject(sb);
    }

    SelectObject(dc, op);
    DeleteObject(penBorder);
    EndPaint(hwnd, &ps);
}

// auto set '.' on textbox
static void FormatEditLive(HWND h, bool allowNegative) {
    char buf[128];
    GetWindowTextA(h, buf, 128);
    DWORD selStart = 0, selEnd = 0;
    SendMessageA(h, EM_GETSEL, (WPARAM)&selStart, (LPARAM)&selEnd);

    int digitsBeforeCaret = 0;
    std::string digits;
    bool neg = false;
    for (int i = 0; buf[i]; i++) {
        if (buf[i] >= '0' && buf[i] <= '9') {
            digits += buf[i];
            if ((DWORD)i < selStart) digitsBeforeCaret++;
        }
        else if (buf[i] == '-' && allowNegative && digits.empty()) {
            neg = true;
        }
    }
    if (digits.size() > 18) digits.resize(18);
    size_t nz = digits.find_first_not_of('0');
    if (nz == std::string::npos) { if (!digits.empty()) digits = "0"; }
    else if (nz > 0) { digitsBeforeCaret = std::max(0, digitsBeforeCaret - (int)nz); digits = digits.substr(nz); }

    std::string out;
    int n = (int)digits.size();
    for (int i = 0; i < n; i++) {
        if (i > 0 && (n - i) % 3 == 0) out += '.';
        out += digits[i];
    }
    if (neg) out = "-" + out;
    if (out == buf) return;

    int caret = neg ? 1 : 0, seen = 0;
    for (size_t i = neg ? 1 : 0; i < out.size() && seen < digitsBeforeCaret; i++) {
        caret = (int)i + 1;
        if (out[i] != '.') seen++;
    }
    if (digitsBeforeCaret == 0) caret = neg ? 1 : 0;

    formatting = true;
    SetWindowTextA(h, out.c_str());
    SendMessageA(h, EM_SETSEL, caret, caret);
    formatting = false;
}


LRESULT CALLBACK WndProc(HWND hwnd, UINT msg, WPARAM wParam, LPARAM lParam) {

    switch (msg) {
        case WM_CREATE: {
            const int M = 16;
            const int LX = M, LW = 190;
            const int MX = 222, MW = 300;
            const int RX = 538, RW = 440;

            AddPanel(MX, 60, MW, 290);        // result
            AddPanel(LX, 364, LW, 60);        // % profit
            AddPanel(MX, 364, MW, 60);        // proftNPC
            AddPanel(RX, 12, RW, 412);        // list market

            // offer name
            hOfferName = MakeEdit(hwnd, "OFFER NAME", M, 16, MX + MW - M, 34, ID_OFFERNAME, fBold, 24);

            // definitions
            const int FY = 62, FSTEP = 58;
            const char* names[5] = { "Balance", "Price to Sell", "Price to Buy", "Amount", "Tax %" };
            const char* init[5] = { "", "", "", "1", "2" };
            int ids[5] = { ID_BALANCE, ID_SELL, ID_BUY, ID_AMOUNT, ID_TAX };
            HWND* hs[5] = { &hBalance, &hSell, &hBuy, &hAmount, &hTax };
            for (int i = 0; i < 5; i++) {
                int y = FY + i * FSTEP;
                MakeLabel(hwnd, names[i], LX + 4, y, LW - 8, 18, fSmall, 0, C_MUTED, true);
                *hs[i] = MakeEdit(hwnd, init[i], LX, y + 20, LW, 32, ids[i], fNormal, 21);
            }

            // pre-result
            MakeLabel(hwnd, "PROFIT TOTAL ON MARKET", MX + 14, 66, MW - 28, 24, fBold, 0, C_ACCENT, true);
            AddSeparator(MX + 14, 94, MW - 28);

            const char* rowNames[7] = { "Sell Total", "Buy Total", "Fee Sell", "Fee Buy", "Fee All", "Buy Final", "Sell Final" };
            HWND* rowH[7] = { &hSellTotal, &hBuyTotal, &hFeeSell, &hFeeBuy, &hFeeAll, &hBuyFinal, &hSellFinal };
            int rowId[7] = { ID_LBL_SELLTOTAL, ID_LBL_BUYTOTAL, ID_LBL_FEESELL, ID_LBL_FEEBUY, ID_LBL_FEEALL, ID_LBL_BUYFINAL, ID_LBL_SELLFINAL };
            for (int i = 0; i < 7; i++) {
                int y = 102 + i * 28;
                MakeLabel(hwnd, rowNames[i], MX + 16, y, 110, 24, fNormal, 0, C_MUTED, true);
                *rowH[i] = MakeLabel(hwnd, "0", MX + 130, y, MW - 146, 24, fNormal, SS_RIGHT, 0, false, rowId[i]);
            }
            AddSeparator(MX + 14, 304, MW - 28);
            MakeLabel(hwnd, "Profit Total", MX + 16, 310, 120, 34, fMid, 0, C_TEXT, true);
            hProfit = MakeLabel(hwnd, "0", MX + 130, 310, MW - 146, 34, fMid, SS_RIGHT, 0, false, ID_LBL_PROFIT);

            // profit npc/market
            MakeLabel(hwnd, "PROFIT %", LX, 368, LW, 16, fSmall, SS_CENTER, C_MUTED, true);
            hProfitPercent = MakeLabel(hwnd, "0", LX, 384, LW, 34, fBig, SS_CENTER, 0, false, ID_LBL_PROFITPERCENT);
            MakeLabel(hwnd, "NPC PROFIT TOTAL", MX, 368, MW, 16, fSmall, SS_CENTER, C_MUTED, true);
            hProfitNpc = MakeLabel(hwnd, "0", MX, 384, MW, 34, fBig, SS_CENTER, 0, false, ID_LBL_PROFITNPC);

            // risk
            hDisplay = MakeLabel(hwnd, "", M, 436, MX + MW - M, 34, fNormal, SS_CENTER, C_AMBER, true, ID_LBL_DISPLAY);

            // list
            const int LSTX = RX + 6;
            struct { const char* t; int x, w; DWORD st; } hdr[6] = {
                { "TIME",   COL_TIME,  COL_TIME_W,  SS_LEFT  }, { "TYPE",   COL_TYPE,  COL_TYPE_W,  SS_LEFT },
                { "NAME",   COL_NAME,  COL_NAME_W,  SS_LEFT  }, { "QTY",    COL_QTY,   COL_QTY_W,   SS_RIGHT },
                { "PRICE",  COL_PRICE, COL_PRICE_W, SS_RIGHT }, { "STATUS", COL_STAT,  COL_STAT_W,  SS_LEFT }
            };
            for (auto& h : hdr) MakeLabel(hwnd, h.t, LSTX + h.x, 20, h.w, 20, fSmall, h.st, C_MUTED, true);
            AddSeparator(RX + 10, 44, RW - 20);

            hList = CreateWindowExA(0, "LISTBOX", "", WS_CHILD | WS_VISIBLE | WS_VSCROLL | LBS_NOTIFY |
                LBS_OWNERDRAWFIXED | LBS_HASSTRINGS | LBS_NOINTEGRALHEIGHT,
                LSTX, 48, RW - 12, 370, hwnd, (HMENU)ID_LIST, NULL, NULL);
            SendMessageA(hList, WM_SETFONT, (WPARAM)fNormal, TRUE);
            SendMessageA(hList, LB_SETITEMHEIGHT, 0, 30);

            // btn
            const int BW = 104, BG = 8;
            hBtnSell = MakeButton(hwnd, "Sell", RX + 0 * (BW + BG), 436, BW, 34, ID_BTN_SELL);
            hBtnBuy = MakeButton(hwnd, "Buy", RX + 1 * (BW + BG), 436, BW, 34, ID_BTN_BUY);
            hBtnCancel = MakeButton(hwnd, "Cancel Offer", RX + 2 * (BW + BG), 436, BW, 34, ID_BTN_CANCEL);
            hBtnDone = MakeButton(hwnd, "Finalize Offer", RX + 3 * (BW + BG), 436, BW, 34, ID_BTN_DONE);

            LoadConfig();
            UpdateBalanceEdit();
            char buf[32]; sprintf(buf, "%d", taxPercent); SetText(hTax, buf);
            RefreshList();
            GetCalculate();
            initializing = false;
            return 0;
        }
        case WM_PAINT:
            PaintBackground(hwnd);
            return 0;
        case WM_CTLCOLORSTATIC: {
            HDC dc = (HDC)wParam; HWND c = (HWND)lParam;
            bool inPanel = InsidePanel(hwnd, c);
            SetBkColor(dc, inPanel ? C_PANEL : C_BG);

            COLORREF col = C_TEXT;
            auto it = labelColor.find(c);
            if (it != labelColor.end()) {
                col = it->second;
            }
            else if (c == hFeeSell || c == hFeeBuy || c == hFeeAll) {
                col = (GetText(c) == "0") ? C_MUTED : C_RED;   // taxa zero fica discreta
            }
            else if (c == hProfit || c == hProfitNpc || c == hProfitPercent) {
                std::string t = GetText(c);
                bool neg = !t.empty() && t[0] == '-';
                bool nonZero = false;
                for (char ch : t) if (ch >= '1' && ch <= '9') nonZero = true;
                col = !nonZero ? C_TEXT : (neg ? C_RED : C_GREEN);
            }
            SetTextColor(dc, col);
            return (LRESULT)(inPanel ? brPanel : brBg);
        }
        case WM_CTLCOLOREDIT: {
            HDC dc = (HDC)wParam;
            SetTextColor(dc, C_TEXT);
            SetBkColor(dc, C_EDIT);
            return (LRESULT)brEdit;
        }
        case WM_CTLCOLORLISTBOX: {
            HDC dc = (HDC)wParam;
            SetTextColor(dc, C_TEXT);
            SetBkColor(dc, C_PANEL);
            return (LRESULT)brPanel;
        }
        case WM_DRAWITEM: {
            LPDRAWITEMSTRUCT d = (LPDRAWITEMSTRUCT)lParam;
            if (d->CtlID == ID_LIST) DrawOfferItem(d);
            else DrawButton(d);
            return TRUE;
        }
        case WM_COMMAND: {
            int id = LOWORD(wParam);
            if (id == ID_BALANCE || id == ID_SELL || id == ID_BUY || id == ID_AMOUNT || id == ID_TAX || id == ID_OFFERNAME) {
                if (HIWORD(wParam) == EN_CHANGE && !initializing && !formatting) {
                    if (id == ID_BALANCE)      FormatEditLive(hBalance, true);
                    else if (id == ID_SELL)    FormatEditLive(hSell, false);
                    else if (id == ID_BUY)     FormatEditLive(hBuy, false);
                    else if (id == ID_AMOUNT)  FormatEditLive(hAmount, false);
                    if (id == ID_BALANCE) { balance = GetInt(hBalance); lastSaveReason = "balance_change"; SaveConfig(); }
                    if (id == ID_TAX) { taxPercent = GetInt(hTax); lastSaveReason = "tax_change"; SaveConfig(); }
                    GetCalculate();
                }
            }
            if (id == ID_LIST) {
                if (HIWORD(wParam) == LBN_SELCHANGE) {
                    int sel = (int)SendMessageA(hList, LB_GETCURSEL, 0, 0);
                    if (sel >= 0 && sel < (int)offers.size()) {
                        Offer& o = offers[sel];
                        SetText(hOfferName, o.name);
                        SetText(hAmount, FmtInt(o.amount));
                        if (o.type == 1) {
                            SetText(hSell, FmtInt(o.sell));
                            SetText(hBuy, FmtInt(o.buy));
                        }
                        else {
                            SetText(hSell, FmtInt(o.sell));
                            SetText(hBuy, FmtInt(o.buy));
                        }
                        char tbuf[32]; sprintf(tbuf, "%d", o.tax); SetText(hTax, tbuf);
                        GetCalculate();
                    }
                }
            }
            if (id == ID_BTN_SELL) {
                GetCalculate();
                std::string name = GetText(hOfferName);
                long long sell = GetInt(hSell);
                long long buy = GetInt(hBuy);
                long long amount = GetInt(hAmount);
                SYSTEMTIME st; GetLocalTime(&st);
                char timebuf[32]; sprintf(timebuf, "%02d:%02d:%02d", st.wHour, st.wMinute, st.wSecond);
                Offer o; o.time = timebuf; o.type = 1; o.name = name; o.amount = amount; o.buy = buy; o.sell = sell; o.status = 3; o.tax = taxPercent;
                offers.push_back(o);
                long long totalSell = sell * amount;
                long long feeSell = CalculateFee(totalSell, taxPercent);
                balance -= feeSell;
                UpdateBalanceEdit();
                lastSaveReason = "btn_sell";
                SaveConfig();
                RefreshList();
            }
            if (id == ID_BTN_BUY) {
                GetCalculate();
                std::string name = GetText(hOfferName);
                long long sell = GetInt(hSell);
                long long buy = GetInt(hBuy);
                long long amount = GetInt(hAmount);
                SYSTEMTIME st; GetLocalTime(&st);
                char timebuf[32]; sprintf(timebuf, "%02d:%02d:%02d", st.wHour, st.wMinute, st.wSecond);
                Offer o; o.time = timebuf; o.type = 2; o.name = name; o.amount = amount; o.buy = buy; o.sell = sell; o.status = 3; o.tax = taxPercent;
                offers.push_back(o);
                long long totalBuy = buy * amount;
                long long feeBuy = CalculateFee(totalBuy, taxPercent);
                balance -= (totalBuy + feeBuy);
                UpdateBalanceEdit();
                lastSaveReason = "btn_buy";
                SaveConfig();
                RefreshList();
            }
            if (id == ID_BTN_DONE) {
                int sel = (int)SendMessageA(hList, LB_GETCURSEL, 0, 0);
                if (sel < 0 || sel >= (int)offers.size()) break;
                Offer& o = offers[sel];
                long long totalBuy = o.buy * o.amount;
                long long totalSell = o.sell * o.amount;
                int doneType = (o.type == 1) ? 1 : 2;
                long long balanceChange = (doneType == 1) ? totalSell : ((doneType == 0) ? totalBuy : 0);
                balance += balanceChange;
                o.status = doneType;
                UpdateBalanceEdit();
                lastSaveReason = "btn_done";
                SaveConfig();
                RefreshList();
            }
            if (id == ID_BTN_CANCEL) {
                int sel = (int)SendMessageA(hList, LB_GETCURSEL, 0, 0);
                if (sel < 0 || sel >= (int)offers.size()) break;
                Offer& o = offers[sel];
                long long totalBuy = o.buy * o.amount;
                balance += totalBuy;
                o.status = 0;
                UpdateBalanceEdit();
                lastSaveReason = "btn_cancel";
                SaveConfig();
                RefreshList();
            }
            break;
        }
        case WM_DESTROY:
            lastSaveReason = "destroy";
            SaveConfig();
            PostQuitMessage(0);
            return 0;
    }
    return DefWindowProcA(hwnd, msg, wParam, lParam);
}

int WINAPI WinMain(HINSTANCE hInst, HINSTANCE, LPSTR, int nCmdShow) {

    INITCOMMONCONTROLSEX icc; icc.dwSize = sizeof(icc); icc.dwICC = ICC_LISTVIEW_CLASSES; InitCommonControlsEx(&icc);

    brBg = CreateSolidBrush(C_BG);
    brPanel = CreateSolidBrush(C_PANEL);
    brEdit = CreateSolidBrush(C_EDIT);
    fNormal = MakeFont(-16, FW_NORMAL, "Segoe UI");
    fSmall = MakeFont(-13, FW_SEMIBOLD, "Segoe UI");
    fBold = MakeFont(-16, FW_SEMIBOLD, "Segoe UI");
    fMid = MakeFont(-22, FW_BOLD, "Segoe UI");
    fBig = MakeFont(-28, FW_BOLD, "Segoe UI");

    WNDCLASSEXA wc = { 0 };
    wc.cbSize = sizeof(wc);
    wc.lpfnWndProc = WndProc;
    wc.hInstance = hInst;
    wc.hCursor = LoadCursor(NULL, IDC_ARROW);
    wc.hbrBackground = brBg;
    wc.lpszClassName = "MarketRubinotCpp";
    RegisterClassExA(&wc);

    DWORD style = (WS_OVERLAPPEDWINDOW & ~WS_THICKFRAME & ~WS_MAXIMIZEBOX) | WS_CLIPCHILDREN;
    RECT rc = { 0, 0, 994, 484 };
    AdjustWindowRect(&rc, style, FALSE);

    HWND hwnd = CreateWindowExA(0, "MarketRubinotCpp", "Market Calculator - by RCP91", style, CW_USEDEFAULT, CW_USEDEFAULT, rc.right - rc.left, rc.bottom - rc.top, NULL, NULL, hInst, NULL);
    ShowWindow(hwnd, nCmdShow);
    UpdateWindow(hwnd);

    MSG msg;
    while (GetMessageA(&msg, NULL, 0, 0)) {
        TranslateMessage(&msg);
        DispatchMessageA(&msg);
    }
    return (int)msg.wParam;
}