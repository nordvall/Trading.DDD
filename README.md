Trading.DDD
===========

Domain Driven Design excersise. The use cases are from an architecure course.


AuctionContext
--------------
Bounded Context containing the auctions and the bidding. 

**Implemented use cases:**

* A Seller creates an auction by providing an item and a minimum price
* Other customers can place bids on the auction. Bids must be higher than last bid and the minimum price.

**Future use cases:**

* Seller can close the auction whenever she wants
* Bids can not be placed after the auction has closed

CustomerContext
---------------
Bounded Context containing the customers. 

**Implemented use cases:**

* A customer can be created, if a name is provided
* The name of the customer can be changed 

**Future use cases:**

* Customers can review each other based on their buying and selling experiences
