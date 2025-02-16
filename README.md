# Turtlelord's Strongly-typed DataFrame

In-progress project to create a DataFrame, similar to the well-known object from the python pandas library, but with strong typing. Writing comprehensively defensive code dealing with complex objects in a dynamically-typed environment is tedious and unsightly, but with a strongly-typed object in a strongly-typed environment, we hope to avoid this for only minor syntactic cost.

Microsoft has written a DataFrame for .NET in the Microsoft.Data.Analysis namespace. The polymorphism on its Series-equivalents requires either similar handling to pandas DataFrames or explicit typechecks.

This project's main mechanism for DataFrame column/element access will be to divide the Series members of a DataFrame into typed categories, which will be accessed by property. Where a pandas DataFrame would get a column with something like `dataframe["diameter"]`, this DataFrame performs a similar access by `dataframe.Numeric["diameter"]`. By adding one (somewhat self-documenting) word to the access interface, we allow both users and the library itself to avoid a significant amount of defensive boilerplate when extracting values.

I am providing static factory classes for object construction.

Exploratory notes:

- Row access on DataFrames is currently projected to be available through two properties, similar to column access syntax. One will return a new DataFrame containing the relevant records, while the other will return a collection of Record data structure objects, which are more convenient to index into for data retrieval. 
	- The possible alternative is not to use a property for row access, and provide a DataFrame method that returns its entire dataset into a Record collection. 
	- Or to provide only the dataframe slicing property and that coversion method.
- I will also be investigating the practicability of making Series immutable, in a departure from the pandas interface (the `inplace` parameter on many operations), also for safety and cleanliness.
- There's also a chance I write a wrapper for convenient use in F# later on.
