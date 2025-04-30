# Team 7 - Intro to SWE Project

Welcome to the Team 7 class project repository for SWE 3313, Introduction to Software Engineering. Our documents, source code, and presentations throughout the project will be located here, with links to each document and presentation in this README markdown file. This repository and README file will be updated accordingly as the project progresses.

Our project will be an e-commerce site built with ASP.NET Core Blazor, with the data being stored with SQLite, that sells used cars to users, and would contain an administration side of the site to manage the inventory and view sales reports. Please have a look at our extensive documentation and planning process within this repository, as well as our source code to view our implementation.

# Project Plan

### Meet our Team:

- [**Justin Owen**](Resumes/Justin_Owen_Resume.md)

- [**William Lane**](Resumes/William_Lane_Resume.md)

- [**Pierre Lopez Orama**](Resumes/Pierre_Lopez_Orama_Resume.md)

- [**Antonio Kinsler**](Resumes/Antonio_Kinsler_Resume.md)

_Background:_
We initially started out discussing our previous experiences to make an informed decision on what tech stack we should utilize. From there, we branched off to the project premise of what we are selling and defined each of our roles for the duration of the project.

### Team Assignments

- The team was divided into different roles based on technologies, with two front-end developers and two back-end developers. The team is also divided by what administrative work each individual will undertake.
- Click [here](/Team_Assignments.md) to view the team assignments

### Technology Selection

- The project will be coded in C# with the ASP.NET Core Blazor framework and a database implementation with SQLite
- Click [here](/Technology_Description.md) to view our technology decisions, the why of those decisions, and the documentation of each technology

### Project Gantt Chart

- Click [here](https://pierretutel.youtrack.cloud/gantt-charts/226-1) to view our detailed project plan, with timelines

### Requirements Introduction

Following our client elicitation, our team has drafted a few requirements documents to help further digest and explain the intended requirements and uses for "Lucky's Cars"

- [Requirements Writing](/Requirements/Requirements_Writing.md)

- [Decision Table](/Requirements/DecisionTable.pdf)

- [Use Case Diagram](/Requirements/UseCaseDiagram.pdf)

### UI Mockup Design

Below is a link to a MarvelApp website mockup, which illustrates our vision for "Lucky's Cars"

- [www.luckyscars.com](https://marvelapp.com/prototype/116j4eea)

Due to the temporary nature of the above example, the site does NOT contain a "log out" feature. If you wish to see a different user type, please refresh the page by clicking the link again. 

### Technical Design

This section details our system for implementation. 

- [Languages and Frameworks](/Technical_Design_Document.md)

- [Entity Relationship Diagram](https://www.mermaidchart.com/raw/26a8b5af-2b36-47ac-a59b-302b8c635ee6?theme=light&version=v0.1&format=svg)
  
- [Entity Description Tables](/Description_Tables.md)
  
- [Example Entity Data](/Example_Data.md)

- [Coding Style Sheet](/Coding_Style_Guide.md)

- [Seed Data](/Seed_Data.md)

- [Data Storage Plan](/Data_Storage_Plan.md)


###Project Implementation
Finally, it is time to show off our demo project for the brand new "Lucky's Cars!" Online Car Sales website. This site is intended to allow customers to browse and purchase used cars of various means. It is also there to allow staff at Lucky's Cars to add and edit their inventory, manage users, and check sales. 

##Installation
To check out the demo, you will need to install some tools. Hopefully in the future this will not be the case, and a single download will do. For now, here are the steps to run the project:

#Step 1:
- Install some form of .Net IDE.
    - Our team recommends Jetbrains Rider, available at this [link](https://www.jetbrains.com/rider/download/)
    - Make sure you select the correct operating system for your machine, be that MacOS or Windows.
        - We did test that so long as there is an IDE to host, and Git framework to download, the application will run on MacOS
#Step 2 (Option 1):
- You can install the Git framework to easily download this application.
  - Use this [link](https://git-scm.com/downloads) to navigate to the downloads page.
  - Windows it is simple, just download and run the installer for Git framework
  - For MacOs, you will need something to adapt the framework, I recommend Homebrew.
    - To install homebrew, go to this [link](https://brew.sh) and copy and paste the listed command line into MacOS terminal application.
    - Let that run to completion, and afterwards run the command "brew install git."
    - Once that is done you can move onto the next step.
#Step 2 (Option 2)
- Click on the Code button at the top of this Github Repository, and select download compressed zip folder.
#Step 3
- You will need to download the .NET 9.0 framework, which is located at this [link](https://dotnet.microsoft.com/en-us/download).
  - Alternatively, Rider will prompt you upon opening the file to download the required .NET files once you complete the next step.
#Step 4
- Inside the IDE, you will need to either open the apllication Luckys_cars.sln, located in this directory: 'Luckys_Cars/Luckys_Cars.sln'
- Alternatively, if you have Git installed, most IDEs have a clone repository option, in which case you simply need to click 'Code' at the top of this repository page, and copy the link there.
  - Then, paste the link into the IDE, which should enable you to clone the repository.
#Step 5
- Once the file is open in the IDE, locate the run button.
  - For those who are using rider, that is the green play button located at the top of the IDE.
##And Thats It!
The app is yours to explore

For those looking to explore our Admin options, please login with the username: Developer_Admin and password: sillyhill795

For Jeff Adkisson, we have already setup an admin account for you under username: JAdkiss1 and password: SecretPassword3313

### Project Presentations

- Click [here](/Presentations/Presentation_Links.md) for a list of recorded presentations of the project deliverables
