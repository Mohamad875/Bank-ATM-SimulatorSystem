<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index9.aspx.cs" Inherits="BankSystem.Index9" %>

<!DOCTYPE html>
<html lang="ar" dir="rtl">
<head runat="server">
    <meta charset="UTF-8">
    <title>Ufuk Bank - Yatırım ve Borsa</title>
    <link rel="stylesheet" href="css/style.css">
    <link rel="stylesheet" href="css/style9.css">
    <link rel="icon" href="css/Images/tree_gallows_horror_halloween_icon_154093.ico" type="image/x-icon">
    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@700&display=swap" rel="stylesheet">
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
</head>

<body>
<!-- ------------------------------- Header ------------------------------- -->
<header>
    <div class="navigation w-nav">
        <div class="navigation-items" style="display: flex; justify-content: space-between; width: 100%; align-items: center;">
            <nav class="navigation-items w-nav-menu" style="display: flex; gap: 30px;">
                <a href="Index.aspx" class="navigation-item w-nav-link">Products</a>
                <a href="Index.aspx" class="navigation-item w-nav-link">About</a>
                <a href="Index.aspx" class="navigation-item w-nav-link">Contact</a>
                <a href="Index.aspx" class="navigation-item w-nav-link">Home</a>
            </nav>
            <div class="logo-container" style="display: flex; align-items: center; justify-content: flex-end; gap: 10px;">
                <span class="site-name" style="font-size: 20px; font-weight: bold;">Ufuk Bankası</span>
                <a href="/" class="logo-link w-nav-brand">
                    <img src="css/Images/tree_gallows_horror_halloween_icon_154093.ico" width="65" alt="Ufuk Bankası" class="logo-image">
                </a>
            </div>
        </div>
    </div>
</header>

<!-- ------------------------------- Content ------------------------------- -->
<div class="content">
    <div class="investment-container">
        <h1 class="investment-title">Yatırım ve Borsa İşlemleri</h1>
        <p class="investment-desc">Yatırım türünü seçin ve yatırım yapmak istediğiniz tutarı girin:</p>

        <form id="investmentForm" runat="server">
            <label for="type" class="form-label">Yatırım Türü:</label>
            <!-- OnSelectedIndexChanged="InvestmentTypeDropdown_SelectedIndexChanged" -->
            <asp:DropDownList ID="InvestmentTypeDropdown" runat="server" CssClass="form-select" AutoPostBack="true" > 
                <asp:ListItem Text="Bitcoin" Value="Bitcoin"></asp:ListItem>
                <asp:ListItem Text="Altın" Value="Altin"></asp:ListItem>
                <asp:ListItem Text="Hisse Senedi" Value="Hisse"></asp:ListItem>
                <asp:ListItem Text="Fon" Value="Fon"></asp:ListItem>
                <asp:ListItem Text="Döviz" Value="Doviz"></asp:ListItem>
                <asp:ListItem Text="Tahvil" Value="Tahvil"></asp:ListItem>
            </asp:DropDownList>

            <label for="amount" class="form-label">Tutar (₺):</label>
            <asp:TextBox ID="AmountTextBox" runat="server" CssClass="form-input" TextMode="Number" Placeholder="Örneğin: 5000"></asp:TextBox>

            <asp:Button ID="InvestButton" runat="server" Text="Yatırım Yap" CssClass="invest-button" />

            <asp:Label ID="ResultMessage" runat="server" CssClass="message-label"></asp:Label>
        </form>

        <!-- Chart -->
        <div class="chart-section">
            <h2 class="chart-title">Yatırım Değer Grafiği</h2>
            <canvas id="investmentChart" height="200"></canvas>
        </div>
    </div>
</div>


<!-- ------------------------------- Döviz Kurları ---------------------------------------- -->
<div class="currency-section">
    <h2 class="currency-title">Döviz Kurları (TL)</h2>
    <table class="currency-table">
        <thead>
            <tr>
                <th>Bayrak</th>
                <th>Para Birimi</th>
                <th>Alış</th>
                <th>Satış</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td><img src="css/flags/us.png" alt="USD" width="30" /></td>
                <td>USD</td>
                <td>₺38,0485</td>
                <td>₺40,4020</td>
            </tr>
            <tr>
                <td><img src="css/flags/eu.png" alt="EUR" width="30" /></td>
                <td>EUR</td>
                <td>₺43,4324</td>
                <td>₺46,1189</td>
            </tr>
            <tr>
                <td><img src="css/flags/gb.png" alt="GBP" width="30" /></td>
                <td>GBP</td>
                <td>₺51,5367</td>
                <td>₺54,7245</td>
            </tr>
            <tr>
                <td><img src="css/flags/ch.png" alt="CHF" width="30" /></td>
                <td>CHF</td>
                <td>₺46,2877</td>
                <td>₺49,1509</td>
            </tr>
            <tr>
                <td><img src="css/flags/jp.png" alt="JPY" width="30" /></td>
                <td>JPY</td>
                <td>₺26,3093</td>
                <td>₺27,9367</td>
            </tr>
            <tr>
                <td><img src="css/flags/dk.png" alt="DKK" width="30" /></td>
                <td>DKK</td>
                <td>₺5,8235</td>
                <td>₺6,1837</td>
            </tr>
            <tr>
                <td><img src="css/flags/se.png" alt="SEK" width="30" /></td>
                <td>SEK</td>
                <td>₺3,9584</td>
                <td>₺4,2033</td>
            </tr>
            <tr>
                <td><img src="css/flags/no.png" alt="NOK" width="30" /></td>
                <td>NOK</td>
                <td>₺3,7679</td>
                <td>₺4,0010</td>
            </tr>
            <tr>
                <td><img src="css/flags/ca.png" alt="CAD" width="30" /></td>
                <td>CAD</td>
                <td>₺27,8315</td>
                <td>₺29,5531</td>
            </tr>
            <tr>
                <td><img src="css/flags/au.png" alt="AUD" width="30" /></td>
                <td>AUD</td>
                <td>₺24,7353</td>
                <td>₺26,2654</td>
            </tr>
            <tr>
                <td><img src="css/flags/sa.png" alt="SAR" width="30" /></td>
                <td>SAR</td>
                <td>₺10,1449</td>
                <td>₺10,7724</td>
            </tr>
            <tr>
                <td><img src="css/flags/gold.png" alt="Altın" width="30" /></td>
                <td>Vadesiz Altın</td>
                <td>₺4.022,834464</td>
                <td>₺4.609,497823</td>
            </tr>
        </tbody>
    </table>
</div>



<!-- ------------------------------- Footer ------------------------------- -->
<footer>
    <div class="section">
        <div class="container">
            <div class="w-layout-grid footer">
                <a href="/" class="logo-link"><img src="images/store-logo2x.png" width="65" alt="" class="logo-footer"></a>
                <div class="footer-link-section">
                    <a href="/" class="footer-link">Home</a>
                    <a href="/about" class="footer-link">About</a>
                    <a href="/contact" class="footer-link">Contact</a>
                    <a href="/products" class="footer-link">Products</a>
                </div>
                <div class="footer-follow">
                    <a href="#" class="footer-link">Instagram</a>
                    <a href="#" class="footer-link">Facebook</a>
                </div>
            </div>
        </div>
    </div>
</footer>

<!--  ------------------------------- Chart Script ------------------------------- -->
<script>
    const chartsData = {
        "Bitcoin": [44500, 44200, 45000, 46000, 45800],
        "Altin": [1750, 1765, 1772, 1780, 1768],
        "Hisse": [120, 122, 121, 124, 126],
        "Fon": [55, 57, 56, 59, 60],
        "Doviz": [28, 28.2, 28.4, 28.1, 28.3],
        "Tahvil": [100, 101, 102, 101.5, 103]
    };

    const dropdown = document.getElementById('<%= InvestmentTypeDropdown.ClientID %>');
    const ctx = document.getElementById('investmentChart').getContext('2d');
    let chart;

    function updateChart(type) {
        const data = chartsData[type] || [];
        const labels = ['Pazartesi', 'Salı', 'Çarşamba', 'Perşembe', 'Cuma'];

        if (chart) chart.destroy();

        chart = new Chart(ctx, {
            type: 'line',
            data: {
                labels: labels,
                datasets: [{
                    label: `${type} ₺`,
                    data: data,
                    borderColor: 'black',
                    backgroundColor: 'rgba(0,0,0,0.05)',
                    fill: true,
                    tension: 0.4
                }]
            },
            options: {
                responsive: true,
                plugins: {
                    legend: { display: true }
                }
            }
        });
    }

    window.addEventListener('load', function () {
        updateChart(dropdown.value);
        dropdown.addEventListener('change', () => updateChart(dropdown.value));
    });
</script>

</body>
</html>
