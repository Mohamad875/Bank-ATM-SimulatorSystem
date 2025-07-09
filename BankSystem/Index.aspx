    <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="BankSystem.Index" %>

<!DOCTYPE html>

<html lang="ar" dir="rtl">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Ufuk Bank</title>
    <link rel="stylesheet" href="css/style.css">
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

<!-- ------------------------------- Nav ------------------------------- --> 
<nav>
      <div class="section cc-store-home-wrap">

        <div class="intro-header">
          <div class="intro-content" style="display: flex; justify-content: space-between; align-items: center; flex-direction: row-reverse;">
            
            <div class="intro-text" style="padding-left: 20px; flex: 1;">
              <div class="heading-jumbo" style="text-align: left;">Discover the<br> Future of<br></div>
              <div class="paragraph-bigger cc-bigger-light" style="text-align: left;">At our bank, we redefine the banking experience.<br> Leveraging the latest technology, we offer a<br> seamless and personalized platform that puts you in<br></div>
            
              <div class="button-container" style="margin-top: 20px; display: flex; gap: 15px; justify-content: flex-end;"><div class="button-container" style="margin-top: 20px; display: flex; gap: 15px; justify-content: flex-start;">
                <a href="#" style="padding: 15px 30px; background-color: white; color: black; text-decoration: none; border-radius: 5px; font-size: 16px; text-align: center; width: 150px; border: 1px solid black;">Learn More</a>
                <a href="Index2.aspx" style="padding: 15px 30px; background-color: black; color: white; text-decoration: none; border-radius: 5px; font-size: 16px; text-align: center; width: 150px;">Get Started</a>
              </div>
              </div>
            </div>

            <div class="intro-image" style="flex-shrink: 0; margin-right: -120px;">
              <img src="css/Images/napkin-selection.png" alt="Image" style="max-width: 100%; height: auto;">
            </div>
            
            
          </div>
        </div>

        <div class="container">
          <div class="grid-content" style="display: grid; grid-template-columns: repeat(2, 1fr); grid-gap: 20px; justify-items: center !important; align-items: start !important;">
            
            <div class="text-with-image">
              <div class="Textx" style=" justify-items: center !important; align-items: start !important;">
                <p class="text-top" style="font-weight: bold; font-size: 1.2em; margin: 0;">Innovative Features</p>
                <p class="text-bottom" style="font-size: 1em; color: #555; margin: 5px 0;">Streamline your banking with <br>our cutting-edge digital tools</p>
              
              </div>
              <img src="css/Images/napkin-selection (1).png" alt="Image 1" style="width: 100%; height: auto; border-radius: 10px;">
            </div>
            
            <div class="text-with-image">
              <div class="Texts" style=" justify-items: center !important; align-items: start !important;">
                <p class="text-top" style="font-weight: bold; font-size: 1.2em; margin: 0;">Personalized Guidance</p>
                <p class="text-bottom" style="font-size: 1em; color: #555; margin: 5px 0;">Our team of financial experts is <br>here to provide tailored advice</p>
              </div>
              <img src="css/Images/napkin-selection (2).png" alt="Image 2" style="width: 100%; height: auto; border-radius: 10px;">
            </div>
            
            <div class="text-with-image" style="grid-column: span 2; text-align: center;">
              <div class="Textx">
                <p class="text-top" style="font-weight: bold; font-size: 1.2em; margin: 0;">Trusted Security</p>
                <p class="text-bottom" style="font-size: 1em; color: #555; margin: 5px 0;">Rest assured, your financial <br>information is safeguarded</p>
              </div>
              <img src="css/Images/napkin-selection(3).png" alt="Image 3" style="width: 50%; height: auto; margin: 0 auto; border-radius: 10px;">
            </div>
          </div>
        </div>


      </div>
  </nav>
  
<!-- ------------------------------- Section ------------------------------- --> 
<section>
      <div class="section cc-subscribe-form">
          <div class="container cc-subscription-form">
              <div class="heading-jumbo-small">Monthly Newsletter</div>
              <div class="paragraph-light cc-subscribe-paragraph">Sign up to receive updates from our shop, including new tea selections and upcoming events.</div>
              <div class="form-block w-form">
                  <form id="wf-form-Monthly-Newsletter-Form" name="wf-form-Monthly-Newsletter-Form" class="subscribe-form">
                      <input class="text-field cc-subscribe-text-field w-input" maxlength="256" name="Newsletter-Email" placeholder="Enter your email" type="email" required>
                      <input type="submit" class="primary-button w-button" value="Submit">
                  </form>
                  <div class="status-message w-form-done">
                      <div>Thank you! Your submission has been received!</div>
                  </div>
                  <div class="status-message w-form-fail">
                      <div>Oops! Something went wrong while submitting the form.</div>
                  </div>
              </div>
          </div>
      </div>
  </section>
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
<!-- ----------------------------------------------------------------------- --> 
</body>
</html>
