Feature: Add to cart functionality

@Add_To_Cart
Scenario:Add highest price product into cart
Given User count the products
When User added highest price product into cart
And User click on Checkout button
And User enter firstname, lastname and zipcode
And User click on Continue and Finish button
Then Successful message should be dislayed to the user

@Logout
Scenario: Logout functionality
When User logout from the application
Then User should redireced to the login page