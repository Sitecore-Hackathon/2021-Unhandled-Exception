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
Sitecore has versioning but it is often underutilized or . 
We wanted to implement a change log that documents on a per-field-level how field values changed between item saves, with the final goal of empowering content editors to undo field changes in real time. 
  - Module Purpose
	  - Help content editors revert undesired changes on production
      - Help promote accountability and tracibility within your organization within the content editing process to ensure transparency.
  - What problem was solved (if any)
      - The module enables reverting changes on a field by field basis while also providing a condensed history of item states
  - How does this module solve it
	  - We are tapping into the item:saving event, fetching the field values that were altered, serializing them into XML and writing to the file system. In Sitecore, we built an admin page that lets you view the contents of the XML and enables you to revert to any stored save state.

## Video link
⟹ Provide a video highlighing your Hackathon module submission and provide a link to the video. You can use any video hosting, file share or even upload the video to this repository. _Just remember to update the link below_

⟹ [Replace this Video link](#video-link)



## Pre-requisites and Dependencies

⟹ Does your module rely on other Sitecore modules or frameworks?
- Jquery

_Remove this subsection if your entry does not have any prerequisites other than Sitecore_

## Installation instructions
⟹ Write a short clear step-wise instruction on how to install your module.  
Install the Sitecore Package, which will give you the dll, config, and the aspx.

1. Start docker environment using `.\Start-Hackathon.ps1`
2. Open solution in Visual Studio and run build
3. Use the Sitecore Installation wizard to install the [RevertChangeReport](../RevertChangeReport.zip)

## Usage instructions
⟹ Provide documentation about your module, how do the users use your module, where are things located, what do the icons mean, are there any secret shortcuts etc.
Once package is installed, changes to fields will be tracked. To view an audit of all recorded changes navigate to /sitecore/admin/ChangeLog.aspx.
Browse the list of changes, which can be filtered by value, and click the revert button to revert a field to its previous state.
After clicking the button the reversion will refelct in the log and the content editor.

![Change Log](docs/images/ChangeLog.PNG?raw=true "Change Log")

## Comments
Thanks for organizing, hopefully you like our module!
- Tori, David, Sasha
