var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable(){
    dataTable = $('#tblData').DataTable({
        "ajax":{
            "url": "/Admin/User/GetAll"
        },
        "columns":[
            {"data": "name", "width": "15%"},
            {"data": "email", "width": "15%"},
            {"data": "phoneNumber", "width": "15%"},
            {"data": "company.name", "width": "15%"},
            {"data": "role", "width": "15%"},
            {
                "data":{id:"id",lockoutEnd:"LockoutEnd"}, 
                "render": function (data){
                    //user is currently locked
                    var today = new Date().getTime();
                    var lockout = new Date(data.lockoutEnd).getTime();
                    if(lockout > today){
                        return `<div class="text-center">
        <a class="btn btn-danger text-white" onclick=LockUnlock("${data.id}") style="cursor:pointer; width:100px;">
        <i class="fas fa-lock-open"></i>Unlock
      </a>
                              </div>                  
`;
                    }
                    else{
                        return `<div class="text-center">
        <a class="btn btn-success text-white" onclick=LockUnlock("${data.id}") style="cursor: pointer; width:100px;">
        <i class="fas fa-lock"></i>Lock
        </a>
                                </div>
`;
                    }
                },"width":"40%"
            }
        ],
        "language":{
            "emptyTable": "No data Found"
        },
        "width":"100%"
    });
}

function LockUnlock(id){
            $.ajax({
                type: "POST",
                url: '/Admin/User/LockUnlock',
                data:JSON.stringify(id),
                contentType:"application/json",
                success: function (data){
                    if(data.success){
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
}




