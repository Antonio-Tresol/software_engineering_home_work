
$(document).ready(function() {
    initializeDataTable()
    bindEvents()
})

function initializeDataTable() {
    $('#forestsTable').DataTable({
        language: {
            url: '//cdn.datatables.net/plug-ins/1.13.7/i18n/es-ES.json',
        },
    })
}

function bindEvents() {
    $('#forestsTable').on('draw.dt', function() {
        $('.dataTables_paginate .paginate_button').addClass('rounded-pill')
    })
}