var dataTable;
$(document).ready(function(){
   loadDataTable() 
});
function loadDataTable(){
    dataTable=$('#tblData').DataTable({
        "ajax":{
            "url":"/Admin/Company/GetAll"
        },
        "columns":[
            {"data":"name","width":"10%"},
            {"data":"streetAddress","width":"10%"},
            {"data":"city","width":"10%"},
            {"data":"state","width":"10%"},
            {"data":"postalCode","width":"10%"},
            {"data":"phoneNumber","width":"10%"},
            {
                "data":"isAuthorizedCompany",
                "render":function(data){
                    if(data){
                        return `<input type="checkbox" disabled checked/>`
                    }
                    else {
                        return `<input type="checkbox" disabled />`
                    }
                },
                "width":"10%"
            },
            {
                "data":"id",
                "render":function(data){
                    return `<a class="center">
                       <a href = "/Admin/Company/Upsert/${data}" class="btn btn-success text-white" style="cursor:pointer">
                        <i class = "fas fa-edit"></i>
                    </a>
                    <a class="btn btn-danger text-white" onclick=Delete("/Admin/Company/Delete/${data}") style="cursor:pointer"/>
                    <i class="fas fa-trash-alt"></i>
                    </a>
                    </div>
                    `;
                },
                "width":"20%"
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
        text: " Once delete, you will not able to recover this image file!",
        icon:"warning",
        button:true,
        dangerMode:true,
    }).then((willDelete)=>{
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