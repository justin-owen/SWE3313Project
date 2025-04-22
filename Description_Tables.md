# Description Tables

##### User Table Field Descriptions

| Attribute | Data Type | Key         | Nullable | Notes                                    |
| :-------- | --------- | ----------- | -------- | ---------------------------------------- |
| userId    | INTEGER   | Primary Key | False    |                                          |
| name      | TEXT      |             | False    |                                          |
| email     | TEXT      |             | False    |                                          |
| username  | TEXT      |             | False    |                                          |
| password  | TEXT      |             | False    | Minimum of 6 characters                  |
| isAdmin   | INTEGER   |             | False    | Uses SQLite Boolean, which is an integer |

##### Sale Table Field Descriptions

| Attribute | Data Type | Key         | Nullable | Notes                                                        |
| --------- | --------- | ----------- | -------- | ------------------------------------------------------------ |
| saleId    | INTEGER   | Primary Key | False    |                                                              |
| invPrice  | INTEGER   |             | False    | Uses a multiply and divide system to save decimal numbers more accurately in SQLite infrastructure |
| tax       | INTEGER   |             | False    |                                                              |
| shipping  | INTEGER   |             | False    |                                                              |
| userId    | INTEGER   | Foreign Key | False    |                                                              |

##### Inventory Table

| Attribute    | Data Type | Key         | Nullable | Notes                                  |
| ------------ | --------- | ----------- | -------- | -------------------------------------- |
| itemId       | INTEGER   | Primary Key | False    |                                        |
| extColor     | TEXT      |             | False    | Exterior Color                         |
| intColor     | TEXT      |             | False    | Interior Color                         |
| miles        | INTEGER   |             | False    |                                        |
| make         | TEXT      |             | False    |                                        |
| model        | TEXT      |             | False    |                                        |
| year         | INTEGER   |             | False    |                                        |
| features     | TEXT      |             | False    |                                        |
| engine       | TEXT      |             | False    |                                        |
| transmission | TEXT      |             | False    |                                        |
| cost         | INTEGER   |             | False    |                                        |
| saleId       | INTEGER   | Foreign Key | True     | Used to identify items on a sale order |

