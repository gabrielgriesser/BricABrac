// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.


function onTextSaveFile() {
    var textToWrite = document.getElementById('textAreaTodo').value;
    var filename = document.getElementById('text-filename').value;

    if (filename == '') {
        var date = new Date();
        filename = 'Todo' + date.yyyymmdd();
    }
    var blob = new Blob([textToWrite], { type: "text/plain;charset=utf-8" });
    saveAs(blob, filename);
}

Date.prototype.yyyymmdd = function () {
    var mm = this.getMonth() + 1; // getMonth() is zero-based
    var dd = this.getDate();

    return [this.getFullYear(),
    (mm > 9 ? '' : '0') + mm,
    (dd > 9 ? '' : '0') + dd
    ].join('');
};


var openFile = function (event) {
    var input = event.target;

    var reader = new FileReader();
    reader.onload = function () {
        var dataURL = reader.result;
        var output = document.getElementById('pdfReader');
        output.src = dataURL;

        var lblFilename = document.getElementById('lbl-filename');
        lblFilename.innerText = "PDF File opened : "

        var options = {
            height: "1000px",
            pdfOpenParams: { view: 'FitV' }
        };
        PDFObject.embed(dataURL, "#pdfReader", options);

    };
    reader.readAsDataURL(input.files[0]);

};
    