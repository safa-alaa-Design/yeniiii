



$(".custom-file-input").on("change", function () {
    var fileName = $(this).val().split("\\").pop();
    $(this).siblings(".custom-file-label").addClass("selected").html(fileName);
});


//function hasClass(elem, className) {
//    return elem.classList.contains("className");
//}


function DeleteItem(btn) {
    var table = document.getElementById('boyutTable');

    if (btn.id.indexOf("foto") > 0)
        table = document.getElementById('fotoTable');

    else if (btn.id.indexOf("fiyat") > 0)
        table = document.getElementById('fiyatTable');

    else
        table = document.getElementById('boyutTable');



    var rows = table.getElementsByTagName('tr');
       

    var btnIdx = btn.id.replaceAll('btnremove-', '');
    /* var idOfIsDeleted = btnIdx + "__IsDeleted";*/




    if (btn.id.indexOf("foto") > 0) {
        btnIdx = btn.id.replaceAll('btnremovefoto-', '');
        $(btn).closest('tr').hide();
    }
    else if (btn.id.indexOf("fiyat") > 0) {
        btnIdx = btn.id.replaceAll('btnremovefiyat-', '');
        $(btn).closest('tr').hide();
    }

    var idOfIsDeleted = btnIdx + "__IsDeleted";

    if (btn.id.indexOf("foto") > 0)
        idOfIsDeleted = btnIdx + "__IsHidden";

    else if (btn.id.indexOf("fiyat") > 0)
        idOfIsDeleted = btnIdx + "__IsHidden";

    var hidIsDelId = document.querySelector("[id$='" + idOfIsDeleted + "']").id;
    document.getElementById(hidIsDelId).value = "true";
    $(btn).closest('tr').hide();

    //$(btn).closest('tr').remove();

  
      
}
 
function AddItem(btn) {




    var table = document.getElementById('boyutTable');
   
     if (btn.id == 'btnfoto')
        table = document.getElementById("fotoTable");

     else if (btn.id == 'btnfiyat')
        table = document.getElementById("fiyatTable");

    
    else
        table = document.getElementById("boyutTable");


    var rows = table.getElementsByTagName('tr');


    var lastrowIdx = rows.length - 1;


    var rowOuterHtml = rows[lastrowIdx].outerHTML;
    lastrowIdx = lastrowIdx - 1;

    var nextrowIdx = eval(lastrowIdx) + 1;

    console.log('Last Row Idx= ' + lastrowIdx)
    console.log('Last Row Idx= ' + nextrowIdx)
 

    rowOuterHtml = rowOuterHtml.replaceAll('_' + lastrowIdx + '_', '_' + nextrowIdx + '_');
    rowOuterHtml = rowOuterHtml.replaceAll('[' + lastrowIdx + ']', '[' + nextrowIdx + ']');
    rowOuterHtml = rowOuterHtml.replaceAll('-' + lastrowIdx, '-' + nextrowIdx);


    var newRow = table.insertRow();
    newRow.innerHTML = rowOuterHtml;













    //var table = document.getElementById('boyutTable');
   
    //if (btn.id == 'btnfoto') 
    //    table = document.getElementById("fotoTable");
      
    //else
    //    table = document.getElementById("boyutTable");

    //var rows = table.getElementsByTagName('tr');

    //var rowOuterHtml = rows[rows.length - 1].outerHTML;

    //var lastrowIdx = document.getElementById('hdnLastIndex').value;

    //var nextrowIdx = eval(lastrowIdx) + 1;

    //document.getElementById('hdnLastIndex').value = nextrowIdx;

    //rowOuterHtml = rowOuterHtml.replaceAll('_' + lastrowIdx + '_', '_' + nextrowIdx + '_');
    //rowOuterHtml = rowOuterHtml.replaceAll('[' + lastrowIdx + ']', '[' + nextrowIdx + ']');
    //rowOuterHtml = rowOuterHtml.replaceAll('-' + lastrowIdx, '-' + nextrowIdx);


    //var newRow = table.insertRow();
    //newRow.innerHTML = rowOuterHtml;



    //var btnAddID = btn.id;
    //var btnDeleteid = btnAddID.replaceAll('addbtn', 'btnremove');

 


}



           