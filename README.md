<h1>Index</h1>

<ul>
<li>
    Overview
    <ul>
        <li>Ovid - Social Retail Platform</li>
        <li>Architecture</li>
        <li>Deployment</li>
        <li>Using This Repository</li>
    </ul>
</li>
<li>
    [Api Hosting Project / With Identity Server](https://github.com/Synoki-Labs/Ovid/tree/main/Ovid.Web.Api)
</li>
<li>
[Ovid Tools Library](https://github.com/Synoki-Labs/Ovid/tree/main/Ovid.Tools)
</li>
<li>
[Ovid Mobile](https://github.com/Synoki-Labs/Ovid/tree/main/Ovid.Mobile)
</li>
<li>
[GraphQl Extensions](https://github.com/Synoki-Labs/Ovid/tree/main/Ovid.GraphQL.Extensions)
</li>
<li>
[Ovid Identity Server Extensions](https://github.com/Synoki-Labs/Ovid/tree/main/Ovid.Auth.Extension)
</li>
<li>
[Ovid Shared Data Model](https://github.com/Synoki-Labs/Ovid/tree/main/Ovid.Data)
</li>
<li>
[Git Lab Documents Runner](https://github.com/Synoki-Labs/Ovid/tree/main/Ovid.GitLabDocument)
</li>
<li>
[Documents](https://github.com/Synoki-Labs/Ovid/tree/main/Documents)
<ul>
<li>
[Generated Models](https://github.com/Synoki-Labs/Ovid/tree/main/Documents/Generated/Ovid/Data)
</li>
</ul>
</li>
</ul>



<h1><u>Ovid</u> - <span style="font-size:20px">Social Retail Platform</span></h1>
<p>
The platform, currently called “Ovid” after the poet who wrote the Greek myth of Narcissus, will provide user’s with an interlinked social media platform to share their purchases with their circles and promote products. Sponsored products will provide a chance for users to earn income when their links are used to purchase an item they have promoted. 
</p>
<p>
 Marketers will be able to track the purchases made through the system and the users that are responsible for driving their traffic. This allows Marketer to mange their social media campaigns and place their marketing dollars where they see a return. 
 </p>
 <p>
The connection between different social media account, using public API’s and User’s permissions, allows the system to target the friends and followers of a vast user group. Analytically data regarding buying habits, social links and product endorsement will provide marketers with the data they need to generate new campaigns and companies with time critical information on product offerings.
</p>
<p>
The users are ranked using a "reputation" system. Points are earned when users connect social media accounts, sell sponsored products through clicks, and reach certain follower goals. The point system can then be used by marketer's
to gauge the impact of user's.  At certain levels of reputation user's will become "influencer's" at which point they wil be able to use platform tools to receive  promotional packages from sponsors. This will be a partnership between the marketer's and the influencer's to provide reviews and tutorials on their various social media accounts through tools provides by the Ovid platform. 
</p>

``` mermaid
graph TD
     FacbookAPI[Facbook API] -.-> Internet([Internet])
    AmazonAPI[Amazon API] -.-> Internet([Internet])
    InstagramAPI[Instagram API] -.-> Internet([Internet])
    TwitterAPI[Twitter API] -.-> Internet([Internet])
    ABZSocialPlatform[ABZ Social Platform] -.-> Internet([Internet])
    Internet([Internet]) == auth.domain.com ==> OvidGraph([GraphQL / Identity Server End Point]) 
    Internet([Internet]) == graph.domain.com ==> OvidGraph 
    Internet([Internet]) == doamin.com  ==> Web([Web Portal])
    Internet([Internet]) == marketer.domain.com ==> Sales([Marketer's Portal])
    Mobile([Mobile Aplication]) --> OvidGraph
    Web([Web Portal]) --> OvidGraph
    Sales([Marketer's Portal]) --> OvidGraph
    OvidGraph --> Auth[(Auth DB)]
    OvidGraph --> Data[(General DB)]
    OvidGraph --> SalesDB[(Sales DB)]
```

<h3>Architecture</h3>
<p>
The majority of the business logic and data logic is provides by the GraphQL API hosted on the main site subdomain.  “graph.domain.com” is the main entry point for both the mobile and web based applications.  When requesting data or preforming a mutation the application will hit the GraphQL endpoint.  
</p>
<p>
Authorization and Authentication is handled by the IdenityServer4 running either on the same address to reduce IP endpoints, or on a subdomain such as “auth.domain.com”. The IdenitryServer4 provides local authentication for users, but also manages and handles the remote API Authentication required by the external providers. Token management is handled by the Auth Database, and identity server is used to refresh external tokens. 
</p>
<p>
User account data is held in the general Database, this includes data about purchases posted, and current status with marketer’s, likes and dislikes, messages and post, and general account data published in the GraphQL API.  
Sale’s Data is stored on its own and is linked to user accounts. The sales side of the data is primarily intended for analytical data, and marketer retention.  As the general user base will not need access to the data it is stored in a separate data store and can only be access via the sales portal with special local account login. 
</p>
<p>
In order to on-board new users the main site provides the main access point for the system. User will learn about the system, explore accounts, and explore trending products and accounts. Target advertisements and related market data can be feed to each users feed based on their purchase and view history. 
Data from social media feeds can also provide the analytics engine with recommendations, friend’s recommendations, follower recommendations, and more interactive experiences. The ability to post from the Ovid platform and generate, Tweets, Instagram post and much more will keep user active on the platform. 
</p>
<p>
As a user begins to use the platform more they will want to bring their experience with them. Providing a mobile application, written in Xamriam and complied to native code, allows user to use the device capabilities of their phone to interact with the application. Providing the ability to directly post pictures and geo tagged information on the go. Xamriam allows the mobile client code to be written in a command language with shared libraries between IOS, and Android, UWP. The code is then generated into platform native languages and complied for the device platform. This allow for fast native like application with one code base to maintain. 
</p>
<h3>Deployment</h3>
<p>
The main application is deployed as a web based application using DotNet 5.0. This is a cross platform package that can be deployed and run on all major web servers including IIS, Apache, Nginx, and more. The application runs on a super fast Kestrel server and proxies via the web server, or in the case of Docker provides access to application ports. The deployment depends on the scenario being used to host the application. 
</p>
<h4>Single Server Deployment</h4>
<p>
A single server deployment allows Ovid to be deployed using a single IP and certificate. The Authentication, and API services are hosted by a single endpoint. This simplifies the deployment of the application and is only advised for evaluation and development. 
The server extension are run on an empty DotNet 5.0 Web Application. This provides all the required runtime hooks to make the authentication system and the API server available on the address the Web applications is running. 
</p>
<h4>Kubernetes Deployment</h4>
<p>
The recommended production deployment is to move the Authentication Services and API Services into their own endpoints. This provides a layer of abstraction to the security, removing calls to the authentication services from the API server. The main benefit is the ability to load balance separately different models and services of the Ovid Platform. Load balancing and dynamic pod deployment allows the system to horizontally scale at runtime. 
To provide fault tolerance and load balancing the application will required three load balancers and IP pools, One for the authentication endpoint, one for the API endpoint, and a final one for the web interface.  This configuration allows each major component to be scaled and balanced for server load.
</p>

<h1>Using This Repository</h1>
<p>
The Repository contains the back-end development project, split into folders by the Visual Studio project. The best way to us the repository is to branch the main project into a feature folder. For instance the project is already branched to the back-end and main. When changes to the back are made a merge request is generated and the back-end branch is merged to the main after CI passes. A automatic build on the main branch is trigger and if passed it will be merged. 
</p>
<h5>Suggested Actions</h5>
<ul>
<li>Create a feature branch</li>    
<li>Clone the branch to your local development path</li>
<li>Commit changes on feature branch</li>
<li>Run CI Test</li>
<li>Submit Merge Request</li>
</ul>

<h3>Documentation</h3>
<p>
<span style="font-size:15px;font-style:italic">
    In order to use the graphs and class diagram with GitHub you will need a browser extension. GitHub does not generate the mermaid markup for markdown on it's own. This step is not needed for GitLab. <br/>
    [mermaid-diagrams](https://chrome.google.com/webstore/detail/mermaid-diagrams/phfcghedmopjadpojhmmaffjmfiakfil)
</style>
</p>
<p>
The Documents Folder will hold both supportive development documents and the auto generated markdown files created by the Ovid Tools package and a few runners used to generate the Data Models Classes and diagrams. To learn more about the tools please visit the tools [README.md](https://github.com/Synoki-Labs/Ovid/tree/main/Ovid.Tools)
</p>
<p>
It is recommended that you place a README.MD in the root of your project, this should describe the developer responsible for the feature and contact information, a description of the feature, any dependencies from other Ovid components, and any integration information. 
</p>
<p>
A short description on how to run the project or the current development endpoint to access the feature is a helpful tip for anyone developing integration test. 
</p>
<p>
The Documentation Root can be found at [/Documents](https://github.com/Synoki-Labs/Ovid/tree/main/Documents). The Generated folder is automatically generated by the Ovid Tools. Any assets used in Wiki and intended for finial documentation may reside here to be collated into a Help and Documentation section.
</p>