
// 選取另一個父分類時取消選擇底下子分類
$("input[name='ParentCategory']").change(function () {
    $(".ChildCategoryCheckbox").prop("checked", false);
});

// 加入我的最愛
function HeartIconChange() {
    var Icon = document.getElementById('ModalHeartIcon');
    var Modal = new bootstrap.Modal(document.getElementById('HeartModal'));
    var ModalMessage = document.getElementById('HeartModalMessage');
    if (Icon.classList.contains('bi-heart')) {
        Icon.classList.remove('bi-heart');
        Icon.classList.add('bi-heart-fill');
        ModalMessage.innerHTML = "已加入我的最愛";
    } else {
        Icon.classList.remove('bi-heart-fill');
        Icon.classList.add('bi-heart');
        ModalMessage.innerHTML = "已從我的最愛移除";
    }
    Modal.show();
    setTimeout(function () {
        Modal.hide();
    }, 3000);
}


