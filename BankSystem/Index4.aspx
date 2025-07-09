<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index4.aspx.cs" Inherits="BankSystem.Index4" %>

<!DOCTYPE html>

<html lang="ar" dir="rtl">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Ufuk Bank</title>

    <link rel="stylesheet" href="css/style.css">
    <link rel="stylesheet" href="css/style4.css">

    <link rel="icon" href="css/Images/tree_gallows_horror_halloween_icon_154093.ico" type="image/x-icon">
    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@700&display=swap" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css2?family=Playfair+Display:wght@700&display=swap" rel="stylesheet">
</head>

<body>


<!-- ------------------------------- Header ------------------------------- --> 

<header>
  <div class="navigation w-nav">
    <div class="navigation-items" style="display: flex; justify-content: space-between; width: 100%; align-items: center;">
      
      
      <div class="navigation-wrap" style="display: flex; gap: 30px;">

        <nav role="navigation" class="navigation-items w-nav-menu" style="display: flex; gap: 30px;">
          <a href="Index.aspx" class="navigation-item w-nav-link">Products</a>
          <a href="Index.aspx" class="navigation-item w-nav-link">About</a>
          <a href="Index.aspx" class="navigation-item w-nav-link">Contact</a>
          <a href="Index.aspx" class="navigation-item w-nav-link">Home</a>
        </nav>

      </div>

      
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
        <div class="withdraw-container">
            <h1 class="withdraw-title">Para Çekme</h1>
            <p class="withdraw-instruction">Lütfen çekmek istediğiniz tutarı giriniz:</p>
            
            <form id="withdrawForm" runat="server">
                <label for="amount" class="amount-label">Tutar (₺):</label>
                <asp:TextBox ID="AmountTextBox" runat="server" CssClass="amount-input" Placeholder="Örneğin: 1000" TextMode="Number"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="AmountTextBox" ErrorMessage="Tutar girilmesi zorunludur!" ForeColor="Red" />
                
                <p class="max-limit">Maksimum çekim tutarı: 10,000₺</p>
                <asp:Button ID="WithdrawButton" runat="server" CssClass="confirm-button" Text="Çekim Yap" OnClick="WithdrawButton_Click" />
            </form>

            <asp:Label ID="MessageLabel" runat="server" CssClass="message-label"></asp:Label>
        </div>
    </div>
<!-- ------------------------------- Footer ------------------------------- --> 
<footer>
    <div class="section">
        <div class="container">
          <div class="w-layout-grid footer">
            <a href="/" id="w-node-_88a386dd-8f07-0c34-70f0-2d9f87e2971b-87e29718" aria-current="page" class="logo-link w-inline-block w--current"><img src="images/store-logo2x.png" width="65" alt="" class="logo-footer"></a>
            <div id="w-node-_88a386dd-8f07-0c34-70f0-2d9f87e2971d-87e29718" class="label">Menu</div>
            <div id="w-node-_88a386dd-8f07-0c34-70f0-2d9f87e2971f-87e29718" class="links-section-footer">
              <a href="/" aria-current="page" class="footer-link w--current">Home</a>
              <a href="/about" class="footer-link">About</a>
              <a href="/contact" class="footer-link">Contact</a>
              <a href="/products" class="footer-link">Products</a>
              <a href="/blog" class="footer-link">Blog</a>
              <a href="/styleguide" class="footer-link">Styleguide</a>
            </div>
            <div id="w-node-_88a386dd-8f07-0c34-70f0-2d9f87e29724-87e29718" class="label">Categories</div>
            <div id="w-node-_88a386dd-8f07-0c34-70f0-2d9f87e29726-87e29718" class="links-section-footer">
              <div class="w-dyn-list">
                <div role="list" class="w-dyn-items">
                  <div role="listitem" class="w-dyn-item">
                    <a href="#" class="footer-link"></a>
                  </div>
                </div>
                <div class="status-message w-dyn-empty">
                  <div>No items found.</div>
                </div>
              </div>
            </div>
            <div id="w-node-_88a386dd-8f07-0c34-70f0-2d9f87e2972d-87e29718" class="label">Help</div>
            <div id="w-node-_88a386dd-8f07-0c34-70f0-2d9f87e2972f-87e29718" class="links-section-footer">
              <a href="/contact" class="footer-link">Shipping</a>
              <a href="/contact" class="footer-link">Returns &amp; Exchange</a>
              <a href="/contact" class="footer-link">Product Care</a>
            </div>
            <div id="w-node-_88a386dd-8f07-0c34-70f0-2d9f87e29736-87e29718" class="label">Follow</div>
            <div id="w-node-_88a386dd-8f07-0c34-70f0-2d9f87e29738-87e29718" class="links-section-footer">
              <a href="https://www.instagram.com/webflowapp/" target="_blank" class="footer-link">Instagram</a>
              <a href="https://www.facebook.com/webflow/" target="_blank" class="footer-link">Facebook</a>
              <a href="https://twitter.com/webflow" target="_blank" class="footer-link">Twitter</a>
            </div>
            <a id="w-node-_88a386dd-8f07-0c34-70f0-2d9f87e2973f-87e29718" href="https://webflow.com/" target="_blank" class="made-with-webflow w-inline-block"><img src="images/webflow-w-small2x_1webflow-w-small2x.png" width="15" alt="" class="webflow-logo-tiny">
              <div class="paragraph-tiny">Powered by Webflow</div>
            </a>
          </div>
        </div>
      </div>
</footer>

</body>
</html>
