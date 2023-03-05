## #3 Stefan's Newsletter

## How and why I create my own mapper (avoid Automapper)?

#February 27 2023

### The background

Automapper is a popular library in the .NET ecosystem that can help developers automate the mapping of data between different object models.

  

In the beginning I used Automapper constantly and it was a great replacement for the tedious work of typing mapping code. Until the moment when I encountered bigger projects where using Automapper only caused me big problems.

Here I will share my experiences and ways to replace Automapper.

### Why am I not using Automapper?

**• Poor code navigation experience**

When using the default configuration of Automapper to map objects, it can be difficult to trace where a particular field is getting its value from. Even with helpful tools like Visual Studio or Rider and using the "Find Usages" feature, it's not possible to locate the assignment or usage of that field.

**• Hard to debug**

The problem here: fluent configuration. I cannot explain this better than: "Even if you provide mapping code within MapFrom<> method, you can’t put there a breakpoint and expect that program invocation stops when you call Mapper.Map<>() method. And if you have a bug in your mapping code you don’t get an exception in the place where you could potentially expect it." - Cezary Piatek

**• Performance**

AutoMapper can impact the performance of your application, as it takes some time to load during project startup and when mapping between objects. However, in most cases, this should not cause any significant issues.

### So what do I do?

### I create my own mapper

Depending on the complexity of the project and what I want to achieve, I choose a certain way of implementing mapping. In the following, I will highlight a few general ways that I use regularly.

### #1 Using reflection

If I don't have many properties to map, all property names that I need to map in both objects are identical, and performance is not the most important thing for me at the moment (although this is certainly faster than Automapper), I use simple reflection to map all properties.

  
![](https://stefandjokic.tech/images/blog/newsletter3/mapper-using-relfeciton.png)

Usage:

  
![](https://stefandjokic.tech/images/blog/newsletter3/usage-of-mapper-using-reflection.png)

**Potential problem:**

  

The names of the properties in User and UserModel are different. **The solution is to introduce projection by implementing the .Project() method** that will enable such mapping.

  

### #2 Specific Mapper Service

This is the most common way I implement mapping. For a certain entity/DTO, I'm creating a service class that I put in DI. Inside the service class, I implement both mappings. This way I have complete control over the mapping with tremendous ease in debugging and testing the code.

![](https://stefandjokic.tech/images/blog/newsletter3/custom%20mapper%20serice.png)

Usage:

  
![](https://stefandjokic.tech/images/blog/newsletter3/usage%20custom%20mapper%20service.png)

**Potential problem:**

  

Very boring and tedious work - manually writing property mappings.

  

I have a solution for you: **Mapping Generator (Visual Studio plugin)** which is able to scaffold mapping code in design time.

  
![](https://stefandjokic.tech/images/blog/newsletter3/mappergenerator.gif)

### #3 EF .Select() method

I use the .Select() method from EntityFramework mainly when I directly map entities from the domain/database to the DTO without any changes. In an ideal world, I believe there is nothing better than this mapping.

  
![](https://stefandjokic.tech/images/blog/newsletter3/entity%20framework%20select%20method.png)  

That's all from me for today.
