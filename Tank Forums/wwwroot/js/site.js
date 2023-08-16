// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



async function ClickVoteButton(postId, voteButton, voteCountText)
{
    if (ForumPostChangeVote(postId, voteButton.value, voteCountText)) {
        ToggleVoteButtonIcon(voteButton);
    }
    
}

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

function ForumPostRefreshVotes(postId, voteCountText)
{


    $.ajax({
        url: '/ForumPosts/GetVoteCount/',
        type: 'GET',
        data: {'postID': postId},
        dataType: 'json',
        success: function (data) {
            voteCountText.innerHTML = data.voteCount;
        },
        error: function (error) {
            console.log(error);
        }
    });
}

async function ForumPostChangeVote(postId, newVoteValue, voteCountText) {


    $.ajax({
        url: '/ForumPosts/ChangeVoteCount/',
        type: 'POST',
        data: { 'postID': postId, 'voteValue': newVoteValue },
        dataType: 'json',
        success: function (data) {
            ForumPostRefreshVotes(postId, voteCountText);
            return true;
        },
        error: function (error) {
            console.log(error);
        }
    });

    return false;
}

function SetVoteButtonOnLoad(postId, voteButton, voteCategory) {


    $.ajax({
        url: '/ForumPosts/GetVoteStyle/',
        type: 'GET',
        data: { 'postID': postId, 'voteCategory': voteCategory },
        dataType: 'json',
        success: function (data) {
            //Return GetVoteIconOnLoad(voteButton, voteCategory, data.voteStatus);
        },
        error: function (error) {
            console.log(error);
        }
    });
}

function GetVoteIconOnLoad(element, voteCategory, voteStatus) {

    console.log("made it to set vote icon on load");

    if (voteStatus == "upvoteFull" && voteCategory == "upvote") {
        return "~/Images/upvoteIconFull.png";
    }
    else if (voteStatus == "downvoteFull" && voteCategory == "downvote") {
        return "~/Images/downvoteIconFull.png";
    }

    return "";
}
