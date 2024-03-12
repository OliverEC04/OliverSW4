# StockPortfolio
SWD Exercise: Observer patterns

Uses the observer push variant, so an observer is notified whenever a subject's data changes.

GitHub link:
https://github.com/OliverEC04/OliverSW4/tree/main/SWD/StockPortfolio

## Structure
**Stock ⟶ Portfolio ⟶ PortfolioDisplay**

Stock is a subject of Portfolio.

Portfolio observes Stock, and is a subject of PortfolioDisplay.

PortfolioDisplay observes Portfolio.