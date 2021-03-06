![Hackathon Logo](docs/images/hackathon.png?raw=true "Hackathon Logo")
# Sitecore Hackathon 2021

- MUST READ: **[Submission requirements](SUBMISSION_REQUIREMENTS.md)**
- [Entry form template](ENTRYFORM.md)
- [Starter kit instructions](STARTERKIT_INSTRUCTIONS.md)
  

### ⟹ [Insert your documentation here](ENTRYFORM.md) <<

# Hackathon Submission Entry form

> __Important__  
> 
> Copy and paste the content of this file into README.md or face automatic __disqualification__  
> All headlines and subheadlines shall be retained if not noted otherwise.  
> Fill in text in each section as instructed and then delete the existing text, including this blockquote.

You can find a very good reference to Github flavoured markdown reference in [this cheatsheet](https://github.com/adam-p/markdown-here/wiki/Markdown-Cheatsheet). If you want something a bit more WYSIWYG for editing then could use [StackEdit](https://stackedit.io/app) which provides a more user friendly interface for generating the Markdown code. Those of you who are [VS Code fans](https://code.visualstudio.com/docs/languages/markdown#_markdown-preview) can edit/preview directly in that interface too.

## Team name
⟹ Unhandled Exception
## Category
⟹ The best enhancement to the Sitecore Admin (XP) for Content Editors & Marketers
## Description
⟹ Write a clear description of your hackathon entry. 
Sitecore has versioning we don't see it used enough/the user experience for content editors has been more confusing than not. 
We wanted to implement a change log that documents on a per-field-level how field values changed between item saves, with the final goal of giving content editor and "Undo" button on bad saves. 
  - Module Purpose
	  - Help content editors undo undesired changes on production
	  - Help production issues forensics processes - we often get requests saying "we don't know who changed what but prod is down". Seeing which fields were edited and by whom would be very useful.
  - What problem was solved (if any)
	  - Both problems were solved - we have a "Revert" button to jump between the different save states of any item.
  - How does this module solve it
	  - We are tapping into the item:saving event, fetch the field values that were changed, serialize them into XML and write to the file system. In Sitecore we have an admin page that lets you view the contents of the XML and lets you revert to any save state.

## Video link
⟹ Provide a video highlighing your Hackathon module submission and provide a link to the video. You can use any video hosting, file share or even upload the video to this repository. _Just remember to update the link below_

⟹ [Replace this Video link](#video-link)



## Pre-requisites and Dependencies

⟹ Does your module rely on other Sitecore modules or frameworks?
No
- List any dependencies
- Or other modules that must be installed
- Or services that must be enabled/configured

_Remove this subsection if your entry does not have any prerequisites other than Sitecore_

## Installation instructions
⟹ Write a short clear step-wise instruction on how to install your module.  
Install the Sitecore Package, which will give you the dll, config, and the aspx.
> _A simple well-described installation process is required to win the Hackathon._  
> Feel free to use any of the following tools/formats as part of the installation:
> - Sitecore Package files
> - Docker image builds
> - Sitecore CLI
> - msbuild
> - npm / yarn
> 
> _Do not use_
> - TDS
> - Unicorn
 
f. ex. 

1. Start docker environment using `.\Start-Hackathon.ps1`
2. Open solution in Visual Studio and run build
3. Use the Sitecore Installation wizard to install the [package](#link-to-package)
4. ...
5. profit

### Configuration
⟹ If there are any custom configuration that has to be set manually then remember to add all details here.

_Remove this subsection if your entry does not require any configuration that is not fully covered in the installation instructions already_

## Usage instructions
⟹ Provide documentation about your module, how do the users use your module, where are things located, what do the icons mean, are there any secret shortcuts etc.
Go to production and edit some important value that you weren't supposed to touch and hit save.
Go to /sitecore/admin/ChangeLog.aspx
Hit revert on the top row
????????
PROFIT

Include screenshots where necessary. You can add images to the `./images` folder and then link to them from your documentation:

![Hackathon Logo](docs/images/hackathon.png?raw=true "Hackathon Logo")

You can embed images of different formats too:

![Deal With It](docs/images/deal-with-it.gif?raw=true "Deal With It")

And you can embed external images too:

![Random](https://thiscatdoesnotexist.com/)

## Comments
If you'd like to make additional comments that is important for your module entry.
Thanks for organizing, hopefully you like our module!
- Tori, David, Sasha