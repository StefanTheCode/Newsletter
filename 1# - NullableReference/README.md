# ​Why am I not using Automapper?

**•** **Poor code navigation experience**  
  
When using the default configuration of Automapper to map objects, it can be difficult to trace where a particular field is getting its value from. Even with helpful tools like Visual Studio or Rider and using the "Find Usages" feature, it's not possible to locate the assignment or usage of that field.  
  
  
• **Hard to debug**  
  
The problem here: fluent configuration. I cannot explain this better than: "Even if you provide mapping code within MapFrom<> method, you can’t put there a breakpoint and expect that program invocation stops when you call Mapper.Map<>() method. And if you have a bug in your mapping code you don’t get an exception in the place where you could potentially expect it." - Cezary Piatek  
  
  
• **Performance**  
  
AutoMapper can impact the performance of your application, as it takes some time to load during project startup and when mapping between objects. However, in most cases, this should not cause any significant issues.  

# So what do I do?  

# I create my own mapper

Depending on the complexity of the project and what I want to achieve, I choose a certain way of implementing mapping. In the following, I will highlight a few general ways that I use regularly.  

# #1 Using reflection

If I don't have many properties to map, all property names that I need to map in both objects are identical, and performance is not the most important thing for me at the moment (although this is certainly faster than Automapper), I use simple reflection to map all properties.  

![image](https://user-images.githubusercontent.com/18572114/221499630-3625587a-24d0-42ef-85ee-093492bc8bab.png)


Usage:  
![image](https://user-images.githubusercontent.com/18572114/221499743-a0be630b-633d-45b4-b07e-033c72916a72.png)

**Potential problem:**  
  
The names of the properties in User and UserModel are different.  
The **solution is to introduce projection by implementing the .Project() method** that will enable such mapping.  

# #2 Specific Mapper Service

This is the most common way I implement mapping. For a certain entity/DTO, I'm creating a service class that I put in DI. Inside the service class, I implement both mappings. This way I have complete control over the mapping with tremendous ease in debugging and testing the code.  
  
![image](https://user-images.githubusercontent.com/18572114/221499831-773a2bd4-1d6c-47d4-b69f-db68418ef60e.png)


Usage:  

![image](https://user-images.githubusercontent.com/18572114/221499911-61338565-cce2-4d16-b060-71b4685a04ea.png)


**Potential problem:**  
  
Very boring and tedious work - manually writing property mappings.  
  
I have a solution for you: **Mapping Generator** (Visual Studio plugin) which is able to scaffold mapping code in design time.  

![](https://camo.githubusercontent.com/b5c54a3f13604a68e2a95e0be5fff6b282af99026317693507a10f931a048be9/68747470733a2f2f6369342e676f6f676c6575736572636f6e74656e742e636f6d2f70726f78792f7857413148673273573572696c6e75445f476731746855676a49496257765762556f2d4c67487a4347326431444630456558365a6f636166622d634a2d324d7a4570737173634a315867326b424879494832786661756b33546737325071575a67615f6b7461367965566c4a7735795479585856703952556d64395451427a6e77484264784450596a42534a364346774b73726e513963486452366d2d5341644441775a4b593945585f74555f65744a5a77493d73302d642d65312d66742368747470733a2f2f67616c6c6572792e656f63616d706169676e312e636f6d2f64663061666335342d396437652d313165642d396661332d353362613961316130313832253246313637373434343230343231332d707572655f6d617070696e675f6d6574686f645f6e65776f6e652e676966)

# #3 EF .Select() method

I use the .Select() method from EntityFramework mainly when I directly map entities from the domain/database to the DTO without any changes. In an ideal world, I believe there is nothing better than this mapping.  

![image](https://user-images.githubusercontent.com/18572114/221500175-30364472-05ae-4bdc-9281-d924cc8872ad.png)


That's all from me for today.
