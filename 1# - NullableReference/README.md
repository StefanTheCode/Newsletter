## #1 Stefan's Newsletter

## 3 methods to handle Nullable Reference

###### February 13 2023

### Background

##### Reference types in C# have always been nullable, meaning that variables of any reference type can be assigned a value of null. In previous versions of C#, dereferencing a null variable was permitted without any checks.

##### The Nullable Reference Types feature was introduced in C# 8 to address this issue, and with the release of **.NET 6**, this feature **is now enabled by default**.

### Example

##### Let's say we have a class:

![](https://stefandjokic.tech/images/blog/newsletter1/1.png)

##### In .Net we will get a warning for underlined properties:

  

##### CS8618: Non-nullable field 'Name' must contain a non-null value when exiting constructor. Consider declaring the field as nullable.

### How to handle?

### Method #1

##### Steps:

##### • Open .csproj project file

##### • Inside the PropertyGroup change Nullable to disable

![](https://stefandjokic.tech/images/blog/newsletter1/2.png)

##### **Result**: We won't get any more warnings for null references, but we can potentially run into a Null Reference Exception if we don't check objects for null before using them.

### Method #2

##### Steps:

##### • Make properties nullable reference type **by using "?"**.

![](https://stefandjokic.tech/images/blog/newsletter1/3.png)

### Method #3

##### Steps:

##### • Assign a **default value** to properties.

![](https://stefandjokic.tech/images/blog/newsletter1/4.png)

### Method #4

##### Steps:

##### • Write a compiler directive **#nullable to disable (or enable)** feature.

![](https://stefandjokic.tech/images/blog/newsletter1/5.png)  
  

##### If you have a .NET 6 project, open it now and try it.
