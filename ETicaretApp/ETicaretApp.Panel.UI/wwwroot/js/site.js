function openCreateModal(entityName) {
    $("#divCreateModalDetail").load(entityName + "/Create" + entityName + "Partial");
    $("#modal" + entityName + "Create").modal("toggle");
}

function openEditModal(entityName, id) {
    $("#divEditModalDetail").load(entityName + "/Edit" + entityName + "Partial/" + id);
    $("#modal" + entityName + "Edit").modal("toggle");
}

function openDeleteModal(entityName, id) {
    $("#divDeleteModalDetail").load(entityName + "/Delete" + entityName + "Partial/" + id);
    $("#modal" + entityName + "Delete").modal("toggle");
}
function openDetailModal(entityName, id) {
    $("#divDetailModalDetail").load(entityName + "/Detail" + entityName + "Partial/" + id);
    $("#modal" + entityName + "Detail").modal("toggle");
}