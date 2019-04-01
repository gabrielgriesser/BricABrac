// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.


function onTextSaveFile()
{
  var textToWrite = document.getElementById('textAreaTodo').value;
  var filename = document.getElementById('text-filename').value;

  if(filename == '')
  {
      filename = 'Todo'
  }
  var blob = new Blob([textToWrite], {type: "text/plain;charset=utf-8"});
  saveAs(blob, filename);
}