## #2 Stefan's Newsletter

## How to use ChatGPT in C# application?

#February 20 2023

### The background

ChatGPT (Generative Pre-trained Transforer) is a large language model developed by OpenAI. It is designed to understand natural language input from users and generate appropriate responses using advanced algorithms and machine learning techniques. ChatGPT can be used in a variety of applications, including chatbots, virtual assistants, customer service, and more.

  

Here I will show you how you can integrate/call ChatGPT API using C# programming language in **5 steps in 5 minutes**.

### Step #1

### Add OpenAI NuGet

To integrate ChatGPT, the initial step involves installing the OpenAI C# SDK. This can be accomplished by executing the following command in the Package Manager Console using the NuGet package manager:

![](https://stefandjokic.tech/images/blog/newsletter2/1.png)

### Step #2

### Get API key

In order to be able to call and authenticate to the OpenAI API, it is necessary to generate a unique API key.

To do this:

  

• Visit: https://platform.openai.com/account/api-keys

• Log in

• Create your API Key by clicking on "Create new secret key" button.

![](https://stefandjokic.tech/images/blog/newsletter2/6.png)

### Step #3

### Instantiate OpenAI

After successfully installing the OpenAI C# SDK, the next step is to initialize it by providing your OpenAI API key. To accomplish this, create an instance of the OpenAI class and pass your API key as a parameter.

![](https://stefandjokic.tech/images/blog/newsletter2/2.png)

### Step #4

### Call the API

In order to call the API and get a response to the prompt we set, it is necessary to call the **CreateCompletionAsync()** method, which accepts the following parameters:

  

**1\. prompt**  
A **required string parameter** that specifies the text prompt for which the API will generate a completion.

  

**2\. model**  
A **required string parameter** that specifies the name of the OpenAI model to use for generating the completion. In this case, it is used the **text-davinci-003 model**.

  

**3\. max\_tokens**  
An **optional integer parameter** that controls the maximum number of tokens (words or symbols) in the generated completion. If set to a low number, the completion will be shorter and more concise. If set to a higher number, the completion will be longer and more detailed.

  

**4\. temperature**  
An **optional floating point parameter** - that controls the "creativity" or randomness of the generated completion. A higher temperature value will result in more diverse and unpredictable output, whereas a lower temperature value will result in more conservative and predictable output. In general, a temperature value between 0.5 and 1.0 tends to produce the most interesting and varied results, while a temperature value closer to 0 tends to be more predictable and safe.

![](https://stefandjokic.tech/images/blog/newsletter2/3.png)

### Step #5

### Read and display result

Once the process of generating the completions has concluded, it is possible to exhibit them within your C# application.

![](https://stefandjokic.tech/images/blog/newsletter2/5.png)  
  

Congratulations! By following these straightforward steps, you now have the ability to seamlessly integrate ChatGPT into your C# code and generate text completions using the model. This was a light and short newsletter issue considering that I haven't commented on ChatGPT so far, so I wanted to do something practical.
