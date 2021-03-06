﻿using System.Collections.Generic;
using SharpBucket.V2.Pocos;

namespace SharpBucket.V2.EndPoints{
    /// <summary>
    /// Use this resource to get information associated with an individual repository. 
    /// You can use these calls with public or private repositories. 
    /// Private repositories require the caller to authenticate with an account that has the appropriate authorization.
    /// More info:
    /// https://confluence.atlassian.com/display/BITBUCKET/repository+Resource
    /// </summary>
    public class RepositoryResource{
        private readonly RepositoriesEndPoint _repositoriesEndPoint;
        private readonly string _accountName;
        private readonly string _repository;

        #region Repository Resource

        public RepositoryResource(string accountName, string repository, RepositoriesEndPoint repositoriesEndPoint){
            _repository = repository;
            _accountName = accountName;
            _repositoriesEndPoint = repositoriesEndPoint;
        }

        /// <summary>
        /// Returns a single repository.
        /// </summary>
        /// <returns></returns>
        public Repository GetRepository(){
            return _repositoriesEndPoint.GetRepository(_accountName, _repository);
        }

        /// <summary>
        /// Removes a repository.  
        /// </summary>
        /// <returns></returns>
        public Repository DeleteRepository(){
            return _repositoriesEndPoint.DeleteRepository(_accountName, _repository);
        }

        /// <summary>
        /// Gets the list of accounts watching a repository. 
        /// </summary>
        /// <returns></returns>
        public List<Watcher> ListWatchers(){
            return _repositoriesEndPoint.ListWatchers(_accountName, _repository);
        }

        /// <summary>
        /// List of repository forks, This call returns a repository object for each fork.
        /// </summary>
        /// <returns></returns>
        public List<Fork> ListForks(){
            return _repositoriesEndPoint.ListForks(_accountName, _repository);
        }

        #endregion

        #region Pull Requests Resource

        /// <summary>
        /// Manage pull requests for a repository. Use this resource to perform CRUD (create/read/update/delete) operations on a pull request. 
        /// This resource allows you to manage the attributes of a pull request also. For example, you can list the commits 
        /// or reviewers associated with a pull request. You can also accept or decline a pull request with this resource. 
        /// Finally, you can use this resource to manage the comments on a pull request as well.
        /// More info:
        /// https://confluence.atlassian.com/display/BITBUCKET/pullrequests+Resource
        /// </summary>
        /// <returns></returns>
        public PullRequestsResource PullRequestsResource(){
            return new PullRequestsResource(_accountName, _repository, _repositoriesEndPoint);
        }

        #endregion

        #region Branch Restrictions Resource

        /// More info:
        /// https://confluence.atlassian.com/display/BITBUCKET/branch-restrictions+Resource
        /// <summary>
        /// List the information associated with a repository's branch restrictions. 
        /// </summary>
        /// <returns></returns>
        public object ListBranchRestrictions(){
            return _repositoriesEndPoint.ListBranchRestrictions(_accountName, _repository);
        }

        /// <summary>
        /// Creates restrictions for the specified repository. You should specify a Content-Header with this call. 
        /// </summary>
        /// <param name="restriction">The branch restriction.</param>
        /// <returns></returns>
        public BranchRestriction PostBranchRestriction(BranchRestriction restriction){
            return _repositoriesEndPoint.PostBranchRestriction(_accountName, _repository, restriction);
        }

        /// <summary>
        /// Gets the information associated with specific restriction. 
        /// </summary>
        /// <param name="restrictionId">The restriction's identifier.</param>
        /// <returns></returns>
        public object GetBranchRestriction(int restrictionId){
            return _repositoriesEndPoint.GetBranchRestriction(_accountName, _repository, restrictionId);
        }

        /// <summary>
        /// Updates a specific branch restriction. You cannot change the kind value with this call. 
        /// </summary>
        /// <param name="restriction">The branch restriction.</param>
        /// <returns></returns>
        public BranchRestriction PutBranchRestriction(BranchRestriction restriction){
            return _repositoriesEndPoint.PutBranchRestriction(_accountName, _repository, restriction);
        }

        /// <summary>
        /// Deletes the specified restriction.  
        /// </summary>
        /// <param name="restrictionId">The restriction's identifier.</param>
        /// <returns></returns>
        public object DeleteBranchRestriction(int restrictionId){
            return _repositoriesEndPoint.DeleteBranchRestriction(_accountName, _repository, restrictionId);
        }

        #endregion

        #region Diff Resource

        /// More info:
        /// https://confluence.atlassian.com/display/BITBUCKET/diff+Resource
        /// <summary>
        /// Gets the diff for the current repository.  
        /// </summary>
        /// <param name="options">The diff options.</param>
        /// <returns></returns>
        public object GetDiff(object options){
            return _repositoriesEndPoint.GetDiff(_accountName, _repository, options);
        }

        /// <summary>
        /// Gets the patch for an individual specification. 
        /// </summary>
        /// <param name="options">The patch options.</param>
        /// <returns></returns>
        public object GetPatch(object options){
            return _repositoriesEndPoint.GetPatch(_accountName, _repository, options);
        }

        #endregion

        #region Commits resource

        /// More info:
        /// https://confluence.atlassian.com/display/BITBUCKET/commits+or+commit+Resource
        /// <summary>
        /// Gets the commit information associated with a repository. 
        /// By default, this call returns all the commits across all branches, bookmarks, and tags. The newest commit is first. 
        /// </summary>
        /// <returns></returns>
        public object ListCommits(){
            return _repositoriesEndPoint.ListCommits(_accountName, _repository);
        }

        /// <summary>
        /// Gets the information associated with an individual commit. 
        /// </summary>
        /// <param name="revision">The commit's SHA1.</param>
        /// <returns></returns>
        public Commit GetCommit(string revision){
            return _repositoriesEndPoint.GetCommit(_accountName, _repository, revision);
        }

        /// <summary>
        /// List of comments on the specified commit.
        /// </summary>
        /// <param name="revision">The commit's SHA1.</param>
        /// <returns></returns>
        public object ListCommitComments(string revision){
            return _repositoriesEndPoint.ListCommitComments(_accountName, _repository, revision);
        }

        /// <summary>
        /// To get an individual commit comment, just follow the object's self link.
        /// </summary>
        /// <param name="revision">The commit's SHA1.</param>
        /// <param name="commentId">The comment identifier.</param>
        /// <returns></returns>
        public object GetCommitComment(string revision, int commentId){
            return _repositoriesEndPoint.GetCommitComment(_accountName, _repository, revision, commentId);
        }

        /// <summary>
        /// Give your approval on a commit.  
        /// You can only approve a comment on behalf of the authenticated account.  This returns the participant object for the current user.
        /// </summary>
        /// <param name="revision">The commit's SHA1.</param>
        /// <returns></returns>
        public object ApproveCommit(string revision){
            return _repositoriesEndPoint.ApproveCommit(_accountName, _repository, revision);
        }

        /// <summary>
        /// Revoke your approval of a commit. You can remove approvals on behalf of the authenticated account. 
        /// </summary>
        /// <param name="revision">The commit's SHA1.</param>
        /// <returns></returns>
        public object DeleteCommitApproval(string revision){
            return _repositoriesEndPoint.DeleteCommitApproval(_accountName, _repository, revision);
        }

        #endregion
    }
}