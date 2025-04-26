# Index

Strongly typed Index objects to keep track of records in DataFrames and Series.

Indices are similar to Series, but have slightly different functionality to facilitate lookup and different typing for safety.
Like a Series, an Index is a combination List and Dictionary, implemented by a backing List and a Dictionary from index labels to list positions. 
In a DataFrame, the index's dictionary lookup allows us to bypass Series lookups for a performance increase. Series must still maintain their lookups for when they are accessed individually.
Indices' dictionaries also simplify user manipulation of the data structure by supporting efficient indexer access by element.
For the moment I shall be developing Indices for whom behavior involving duplicate entries is undefined.

Pandas lists 8 types of Index: Index, Numeric Index (actually a Sequence Index), Categorical Index, Interval Index, Multi-Index, Datetime Index, Time Delta Index, and Period Index.

The basic Pandas Index supports strings, numpy types, additional pandas-defined types, and user-defined types. It's a general index.

...

Multiindex is likely the last major structural hurdle to settling on an architecture for this project.