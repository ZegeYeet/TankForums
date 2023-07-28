// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



function ToggleVoteButtonIcon(element)
{

    if (element.value == "upvoteEmpty") {
        element.style.backgroundImage = "url('Images/upvoteIconFull.png')";
        element.value = "upvoteFull";
    }
    else if (element.value == "upvoteFull") {
        element.style.backgroundImage = "url('Images/upvoteIconEmpty.png')";
        element.value = "upvoteEmpty";
    }
    else if (element.value == "downvoteEmpty") {
        element.style.backgroundImage = "url('Images/downvoteIconFull.png')";
        element.value = "downvoteFull";
    }
    else if (element.value == "downvoteFull") {
        element.style.backgroundImage = "url('Images/downvoteIconEmpty.png')";
        element.value = "downvoteEmpty";
    }
}
