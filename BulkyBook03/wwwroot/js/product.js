var dataTable;
$(document).ready(function(){
    loadDataTable();
});

function loadDataTable(){
    dataTable = $('#tblData').DataTable({
        "ajax":{
            "url": "/Admin/Product/GetAll"
        },
        "columns":[
            {"data":"title", "width":"15%"},
            {"data": "isbn","width":"15%"},
            {"data":"price","width":"15%"},
            {"data":"author","width":"15%"},
            {"data":"category.name","width":"15%"},
            {
                "data":"id",
                "render":function(data){
                    return `<div class="text-center">
                                <a href="/Admin/Product/Upsert/${data}" class="btn btn-success text-white" style="cursor:pointer">
                                <i class="fas fa-edit"></i>
</a>
<a class="btn btn-danger text-white" onclick=Delete("/Admin/Product/Delete/${data}") style="cursor:pointer">
<i class="fas fa-trash-alt"></i>
</a>
</div>`;
                }, "width":"40%"
            }
        ],
        "language":{
            "emptyTable":"No data Found"
        },
        "width":"100%"
    });
}
function Delete(url){
    swal({
        title : "Are you sure?",
        text : "Once deleted, you can't recover this image file!",
        icon:"warning",
        button:true,
        dangerMode:true,
    }).then ((willDelete)=>{
        if(willDelete){
            $.ajax({
                type:"DELETE",
                url:url,
                success:function(data){
                    if(data.success){
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else{
                        toastr.error(data.message);
                    }
                }
            })
        }
    })
}



