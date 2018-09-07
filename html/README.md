//----------  README
//------------------------------------------------------------------------------

NOTE: if you have node.js installed, skip to step 3.

1. Download and install node.js https://nodejs.org/en/download/
2. Run node.js command prompt
3. Next run "npm install" to collect all gulp dependencies
4. To compile styles/svgs/html run "gulp" for development watch, or "gulp build" for a clean build

### * SVG SPRITE * ###
To compile svg sprite, run "gulp sprite" command.
Do not forget to add your sprite icon to "_icons.scss" file.
In order to show svg sprit icons, all you need to do is add html "<span class="ico ico-heart"></span>"

### * ICON FONT * ###
Icon font: to generate new icons and create font, run "gulp iconfont" command.
In order to show icons, all you need to do is add html "<span class="icon font-ico-heart"></span>"

### * package.json * ###
NOTE: if package.json is empty or not updating, run "npm init" command.

### * Node modules remove * ###
Removing node_modules folder from the project in Windows is almost impossible,
but you can use SHIFT + DELETE in Total Commander.

We would recommend using rimraf plugin. Type "npm install rimraf -g".
Navigate to the project folder, type "rimraf node_modules" to remove node_modules.

### * Node.js update * ###
1. Uninstall previous version and close all open terminals
2. Install new version
3. Open terminal and type "npm cache clean"
4. Then run "npm install" 

NOTE: If you get error message in compiling project with installed node modules, please remove node_modules folder and install dependencies again. Reason is that dependencies are connected to old Node.js instance.