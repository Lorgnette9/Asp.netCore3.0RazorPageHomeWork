var dataTable;
$(document).ready(function () {
    loadList();
});
    
function loadList() {
    dataTable = $('#DT_load').dataTable({
        "ajax": {
            "url": "/api/MenuItem",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "name", "width": "25%" },
            { "data": "price", "width": "15%" },
            { "data": "category.name", "width": "15%" },
            { "data": "foodType.name", "width": "15%" },
            {
                "data": "id",
                "render": function(data) {
                    return `<div class="text-center">
                <a href="/Admin/MenuItem/upsert?id=${data}" class="btn btn-success text-white" style="cursor:pointer; width:100px;">
                  <i class="far fa-edit"></i>Edit
                </a>        
                     <a class="btn btn-danger text-white" style="cursor:pointer; width:100px;" onclick=Delete('/api/MenuItem/'+${data})>
                    <i class="far fa-trash-alt"></i>Delete
                     </a>        
            </div>`;
                },"width": "30%"
            }
        ],
        "language": {   
            "emptyTable": "no data found."
        },
        "width": "100%",
        "order":[[2,"asc"]]         // aşağı açılan pencere ok'unu kaldırıp direk artan sırada sıralattı
    });
}

function Delete(url) {
    swal({
        title: "Silmek istediğinize emin misiniz?",
        text: "Bu veri geri getirilemeyecek !!",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({        
                type:'DELETE',
                url: url,
                success: function(data) {
                    if (data.success)
                    {
                       toastr.success(data.message);
                       dataTable.ajax.reload();
                    }
                    else
                    {

                       toastr.error(data.message);

                    }

                }
            });
        }
    });
}