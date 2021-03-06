var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url":"/Admin/Employee/GetAll"
        },
        "columns": [
            { "data": "name", "width": "10%" },
            { "data": "email", "width": "10%" },
            { "data": "phone", "width": "10%" },
            { "data": "address", "width": "10%" },
            { "data": "department.name", "width": "10%" },
            { "data": "designation.name", "width": "10%" },
            { "data": "salary", "width": "10%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="w-75 btn-group" role="group">
                        <a href="/Admin/Employee/Upsert?id=${data}"
                        class="btn btn-warning mx-2"> <i class="bi bi-pencil-square"></i> Edit</a>
                        <a onClick=Delete('/Admin/Employee/Delete/${data}')
                        class="btn btn-danger mx-2"> <i class="bi bi-trash-fill"></i> Delete</a>
					</div>
                        `
                },
                "width": "30%"
            }
        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        dataTable.ajax.reload();
                        toastr.success(data.message);
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            })
        }
    })
}