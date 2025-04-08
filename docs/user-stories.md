# User Stories

This document contains user stories for the main features of the application.

### US0: Create a Purchase Order
**As a** procurement manager
**I want to** create a purchase order for a supplier
**So that** I can manage the procurement process efficiently.

### Acceptance Criteria
### Scenario 1: Create a Purchase Order with vailid Supplier
**Given** A supplier with code "SUP123", name "Microsoft Inc.", and address.
**When** the procurement manager creates a purchase order with the supplier.
**Then** the purchase order should be created successfully with the supplier's details.

### Scenario 2: Create a Purchase Order with invalid Supplier
**Given** A supplier with code "SUP123", name "Microsoft Inc.", and address.
**When** the procurement manager creates a purchase order with an invalid supplier.
**Then** the purchase order should not be created and an error message should be displayed.