- **System Overview**
	- Local Storage solution using SQLite for accessibility and simplicity
	- Backup and Redundancy to ensure readability and data security
	- Data collected from Blazor
	- Data Stored in C# and converted to a SQLite database using the Entity Framework

- **Data types**
	- User data (Profiles, userID, email)
	- Transactional data (SalesID, purchase history)
	- Media data (Images of inventory contents)

- **Storage location**
	- Primary storage in the local File system
	- Backup storage on separate file in the local file system

- **Access control (Clearance)**
	- Role based access to limit permissions
	- Entity framework for data retrieval

- **Data Retention**
	- Retain all data until manually removed or modified

- **Backup Strategy** 
	- On-close incremental backup, updating the file with any changes made since the previous instance

