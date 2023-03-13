## #4 Stefan's Newsletter

## GitHub Webhook with C#

> March 06 2023

## The background

A **Webhook** is a mechanism that allows a web application to send real-time notifications or data to another web application.

  

It is essentially a way for two different applications to communicate with each other in "real time" rather than relying on periodic polling or manual data transfer.

  

An example of a simple implementation of a C# Webhook receiver for Github will be shown below.

  

\*\* In this edition of the newsletter, there will be no mention of the implementation of the webhook mechanism (sender & receiver) due to the volume of the problem, which is not adequate for the newsletter.

  

## C# Webhook receiver

A webhook receiver for an event that happened on Github or any other service can be represented in the simplest way as an **HttpPost API endpoint** in a C# controller.

**• Create an action in C# Controller**

You need to create C # API Controller with GitHubWebhookController name. This is a controller to serve for all Events that happen within Github repository.

After that, you need to add an endpoint Pushed for the "push" event on github, which will practically serve as a callback event.

![](https://stefandjokic.tech/images/blog/newsletter4/GitHubWebhookController.png)

This method must be HttpPost.

  

Since I currently don't know what the GitHub payload looks like, ie. object/JSON that GitHub sends during a specific event, I will state that the object that the method receives as a parameter is type dynamic.

  

**• Run the application**

  

When you start the API project, through Swagger you can see Endpoint there is and that everything is fine for now.

  
![](https://stefandjokic.tech/images/blog/newsletter4/Swagger%20-%20API%20Project%20Webhook.png)

## Create Webhook instance on GitHub

Within the GitHub repository for which you want to receive events, you need to generate a Webhook instance. In the repository settings, you should select the Webhooks link from the left menu. And click on the Add webhook button. You should see the following form:

  
![](https://stefandjokic.tech/images/blog/newsletter4/GitHub%20-%20Add%20webhook%20form.png)

The most important field to fill in is of course the **PayloadUrl**.

  

**This field represents the endpoint of our application that Github will call the moment a push event occurs on the selected repository.**

  

**Content type:** You can choose application/json

  

**Secret:** You can generate via some online generator. This secret is used to verify that the payload was actually sent by Github and not by a malicious third party pretending to be Github. For demo purposes I will leave it blank, but do not do this on production.

  

The most important field to fill in is of course the PayloadUrl.

  

Okay, now, what will happen if you put the localhost link **_(http://localhost:7030/api/GithubWebhook/push)_** like a Payload URL?

  

Nothing.

  

GitHub doesn't know that your localhost exists somewhere on your computer. It is necessary that the application is deployed somewhere, say Azure.

  

But for testing and debugging, **ngrok** can help you.

  

**What is ngrok?** .

  

Ngrok is a software tool that creates a secure tunnel between a local machine and the public internet, allowing developers to expose a web server running on their local machine to the internet.

  

**Ngrok setup**.

  

• Download from: [ngrok](https://ngrok.com/)

• Install it and run it.

• Execute the following command: **ngrok http port**

  

_\* Port should be your port which you can see when you start the application._

_\* You should **disable https protocol** for the application by replacing https urls with http in **launchSettings.json**._

  

Now you will see in CMD the url that is online and to which the localhost url is mapped.

  

If you visit the url from the "forwarding" part, you will see exactly the same result as for localhost. Of course, the advantage of this is that the debugger is active.

![](https://stefandjokic.tech/images/blog/newsletter4/ngrok%20CMD.png)

The next thing is to put that ngrok url together with the API endpoint in the Payload Url field:  
**_https://9739-178-220-34-243.eu.ngrok.io/api/GitHubWebhook/pushed_**

## Testing

1\. Run the application

2\. Put a breakpoint in the Pushed method

3\. Go to the repository and make some changes

![](https://stefandjokic.tech/images/blog/newsletter4/Commit%20changes%20-%20Github%20repo.png)

4\. Wait for a couple of seconds, and call should hit the debugger

5\. You can see parameter payload is full of data

![](https://stefandjokic.tech/images/blog/newsletter4/Debugger.png)

## What Next?

On this very simple example, I have shown how a webhook receiver for Github can be implemented.

  

In this way, any service that supports WebHooks works. With the fact that there is a difference from service to service in the payload that is sent, so based on what you need, you will create a class with properties instead of receiving a dynamic type of payload.

  

Also, this can be implemented with Azure Functions, so be sure you do a research on that topic.

  

For GitHub payload for each webhook you can find at: [Github Webhook Documentation](https://docs.github.com/en/webhooks-and-events/webhooks/webhook-events-and-payloads)

  

That's all from me for today.
