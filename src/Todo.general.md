



Re-design entire frontend

Pages:

- index
- cart
- product page
- profile page

Current Goal:

--Complete Cart System.

--Make separate page for add to card.

-- On Click item, get the product details page. 

-- Make it as a link. On click the id of product will  be sent to the page.

https://localhost:7118/ProductDetails?id=64 

get item's product id and send it by that.

On click the pitcure will appear on big screen. Make pitcures list of images and remove imageurls from backend.

-- Profile Page

Total Purchases, last purchases etc etc.


-- Make small cart part for the index page. 

Have these:
products - quantity - x(cancel button)

total products etc. 

go to the cart. 

buy now will be on the same page.

---

> On Click Add To Cart, it will send  the item to the cart system.
> GetU	serName by User.Identity
> Get Other Values by Product.etc

---

--Now i have to connect add to cart to the redis database. - Done

-- Fix The Redis based on these

--> Image Url

--> Product Name

--> Product Id

-- > Product Price

--> Total Quantity"

--> Based On Total Quantity  * Price, calculate the total price

--> Write them on the checkout

--> Add Remove Product

New Idea, get the image url based on ProductId

--**Complete Payment System.**

-----  Search The Payment Systems

Some New Features to add

E-Mail System.

Normal Authorization

- Rate Limiting
- Logging. Add Structured Logging for All Services
- Make better frontend.
- Fix Development Json
- Fix Docker-Compose files. - dONE
- Fix Eshop.Web Http, learn how to enable dev-certs inside the dockerfile - Done -> Add Documentation that we need to create the https dev-cert in local machine, then send it to the docker
- Write Bash and Powershell scripts.

important:JBB13ZPTDMJDY367JEWG6BLH

https://stackoverflow.com/questions/69282468/using-dotnet-dev-certs-with-aspnet-docker-image
