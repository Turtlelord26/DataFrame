# Turtlelord's Strongly-typed DataFrame

In-progress project to create a DataFrame, similar to the well-known object from the python pandas library, but with strong typing. Writing comprehensively defensive code dealing with complex objects in a dynamically-typed environment is tedious and unsightly, but with a strongly-typed object in a strongly-typed environment, one hopes to avoid this for only minor syntactic cost.

Microsoft has written a DataFrame for .NET in the Microsoft.Data.Analysis namespace. The polymorphism on its Series-equivalents requires either similar handling to pandas DataFrames or explicit typechecks.

This project's main mechanism for DataFrame column/element access will be to divide the Series members of a DataFrame into typed categories, which will be accessed by property. Where a pandas DataFrame would get a column with something like `dataframe["diameter"]`, this DataFrame performs a similar access by `dataframe.Numeric["diameter"]`. By adding one (helpfully self-documenting) word to the access interface, we allow both users and the library itself to avoid a significant amount of defensive boilerplate when extracting values.
Indexers directly on the DataFrame will support single and multiple row extraction as smaller DataFrames, as well as general cross-sections.

I am providing static factory classes for object construction.
