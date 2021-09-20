var dataTable;
$(document).ready(function(){
    loadDataTabe();
})
function loadDataTable(){
    dataTable=('#tblData').DataTables({
        "ajax":{
            "url":"/Admin/Edition/GetAll",
            "columns":[
                {"data":"name","width":"10%"},
                {"data":"id",
                "render":function(data){
                    return `
                    <`
                }
                }
            ]
        }
        
    })
}