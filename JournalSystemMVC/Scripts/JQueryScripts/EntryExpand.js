$(".entryHeader").click(function () {
    var $entryHeader = $(this);
    var $entryContent = $entryHeader.next();
    $entryContent.slideToggle(300);
});