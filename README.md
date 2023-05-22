# <img src="https://github.com/sannafis/PaletteStudioReadMe/assets/119695583/8b51f280-6bd5-49fe-98a4-f1c51e8e51d4" width="50"/>Palette Studio - Project (WIP)
## About 

<details open>
  <summary><strong>Expand / Collapse</strong></summary>
  
<br/>
  
### What is Palette Studio?

  'Palette Studio' is a project with the end goal of making an application using ASP.NET Core to help create user-friendly colour palettes.
  The main component being a palette editor that provides a large amount of flexibility with foreground and background colours,
   of which can be assessed and graded according to WCAG colour contrast requirements.

'Palette Studio' is a project that 
will essentially consist of three parts:

1. **Colour Library** ([View in Repository](https://github.com/sannafis/PaletteStudio/tree/master/ColourLibrary "View the Colour Library source code."))
    - A Library that consists of methods and utilities related to colours that would be utilized throughout the project. 
2. **Palette Studio API** ([View in Repository](https://github.com/sannafis/PaletteStudio/tree/master/PaletteStudioApi "View the API source code.")) ([Swagger Demo](https://palettestudioapidemo.azurewebsites.net/swagger/index.html))
    - Demo Login Username: ```user@palettestudio.ca```  Password: ```P@ssw0rd```
    - A REST API using ASP.NET Core 6 and Sqlite that uses JWT Authentication for users to access their palettes and related data.
3. **Blazor Client Application (Soon)** ([More Details](#web-page-mockups))
    - A Blazor WASM (ASP.NET Core 6) client application that will use the Colour Library and API.

  
  <details>
  
  <summary><strong>Why Blazor?</strong></summary>
  
  During my studies, I was assigned a very open-ended project to choose among ASP.NET Core technologies as 
  the base of the project. I chose to use Blazor, and mocked up the idea of a colour palette editor/grader, mainly 
  for the use of web developers to create colour palettes that align with the contrast requirements of WCAG.
    
  I produced a functional but crude version of what I plan on making for this project. For the timespan I was given, it was a lot to take on, but because of that project, I have become more interested in Blazor and in making a more realized and polished version of my original idea. 
    
  </details>

</details>

## Web Page Mockups

Below are mockups of what I want the final client application to look like.
Main features to be implemented:
- Explore Page
  - View palettes made by other users that are marked as 'Public'.
  - Copy other palettes to your own workspace to view / edit.
- 'My Work' Page
  - User can view and change settings for any palettes that they create.
- Palette Editor
  - This would be the main 'feature' of the site. Users can view and edit a palette here and also view the contrast of those colours.
  - Each palette consists of multiple 'Main' colours. These would also be considered 'Background Colours'.
  - Each Background Colour can have a few Foreground Colours that 
  can be compared to produce a contrast rating and information to view their accordance with the WCAG colour guidelines.
<table>
<tr>
    <td colspan="2" align="center">Home Page<img src="https://github.com/sannafis/PaletteStudioReadMe/assets/119695583/dbc9e79b-1b22-4d82-be86-8b2fc416e2c5" alt="Home" /></td>
    <td colspan="2" align="center">Explore Page (Grid)<img src="https://github.com/sannafis/PaletteStudioReadMe/assets/119695583/408c49d7-1d74-42a4-8961-9c651f78b3af" alt="ExploreGridView" /></td>
    <td colspan="2" align="center">Explore Page (List)<img src="https://github.com/sannafis/PaletteStudioReadMe/assets/119695583/44a27a70-b7b9-49df-a593-5de89ce23db1" alt="ExploreListView" ></td>
  </tr>
  <tr> 
    <td colspan="2" align="center">'My Work' Page (Grid)<img src="https://github.com/sannafis/PaletteStudioReadMe/assets/119695583/c29c0326-e410-4075-925c-38fa6a9f56f5" alt="MyWorkGridView" /></td>
    <td colspan="2" align="center">'My Work' Page (List)<img src="https://github.com/sannafis/PaletteStudioReadMe/assets/119695583/d9913d0d-99f7-4c05-a779-3c77e0b673a5" alt="MyWorkListView" /></td>
    <td colspan="2" align="center">Palette Editor (View Mode)<img src="https://github.com/sannafis/PaletteStudioReadMe/assets/119695583/b02f28b5-73fc-4020-93c3-eda3d7b6042f" alt="PaletteEditor" /></td>
    </tr>
    <tr>
      <td colspan="3" align="center"> Palette Editor - Colour Group Editor Panel<img src="https://github.com/sannafis/PaletteStudioReadMe/assets/119695583/65ed6774-313d-4179-807f-43f5fa045005" alt="PaletteEditorEditCollapse" /></td>
    <td colspan="3" align="center"> Palette Editor - Colour Group Editor Panel (Expanded)<img src="https://github.com/sannafis/PaletteStudioReadMe/assets/119695583/bf296fcc-6dd6-44eb-a13d-00564f6ce88a" alt="PaletteEditorEditWindow" /></td>
</tr>
</table>
