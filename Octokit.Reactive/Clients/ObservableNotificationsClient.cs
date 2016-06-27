﻿using System;
using System.Reactive;
using System.Reactive.Threading.Tasks;
using Octokit.Reactive.Internal;

namespace Octokit.Reactive
{
    /// <summary>
    /// A client for GitHub's Activity Notifications API.
    /// </summary>
    /// <remarks>
    /// See the <a href="http://developer.github.com/v3/activity/notifications/">Activity Notifications API documentation</a> for more information.
    /// </remarks>
    public class ObservableNotificationsClient : IObservableNotificationsClient
    {
        readonly IConnection _connection;
        readonly INotificationsClient _notificationsClient;

        public ObservableNotificationsClient(IGitHubClient client)
        {
            Ensure.ArgumentNotNull(client, "client");

            _connection = client.Connection;
            _notificationsClient = client.Activity.Notifications;
        }

        /// <summary>
        /// Retrieves all of the <see cref="Notification"/>s for the current user.
        /// </summary>
        /// <exception cref="AuthorizationException">Thrown if the client is not authenticated.</exception>
        public IObservable<Notification> GetAllForCurrent()
        {
            return GetAllForCurrent(ApiOptions.None);
        }

        /// <summary>
        /// Retrieves all of the <see cref="Notification"/>s for the current user.
        /// </summary>
        /// <param name="options">Options for changing the API response</param>
        /// <exception cref="AuthorizationException">Thrown if the client is not authenticated.</exception>
        public IObservable<Notification> GetAllForCurrent(ApiOptions options)
        {
            Ensure.ArgumentNotNull(options, "options");

            return _connection.GetAndFlattenAllPages<Notification>(ApiUrls.Notifications(), options);
        }

        /// <summary>
        /// Retrieves all of the <see cref="Notification"/>s for the current user specific to the specified repository.
        /// </summary>
        /// <param name="owner">The owner of the repository.</param>
        /// <param name="name">The name of the repository.</param>
        /// <exception cref="AuthorizationException">Thrown if the client is not authenticated.</exception>
        public IObservable<Notification> GetAllForRepository(string owner, string name)
        {
            Ensure.ArgumentNotNullOrEmptyString(owner, "owner");
            Ensure.ArgumentNotNullOrEmptyString(name, "name");

            return GetAllForRepository(owner, name, ApiOptions.None);
        }

        /// <summary>
        /// Retrieves all of the <see cref="Notification"/>s for the current user specific to the specified repository.
        /// </summary>
        /// <param name="repositoryId">The ID of the repository.</param>
        /// <exception cref="AuthorizationException">Thrown if the client is not authenticated.</exception>
        public IObservable<Notification> GetAllForRepository(int repositoryId)
        {
            return GetAllForRepository(repositoryId, ApiOptions.None);
        }

        /// <summary>
        /// Retrieves all of the <see cref="Notification"/>s for the current user specific to the specified repository.
        /// </summary>
        /// <param name="owner">The owner of the repository.</param>
        /// <param name="name">The name of the repository.</param>
        /// <param name="options">Options for changing the API response</param>
        /// <exception cref="AuthorizationException">Thrown if the client is not authenticated.</exception>
        public IObservable<Notification> GetAllForRepository(string owner, string name, ApiOptions options)
        {
            Ensure.ArgumentNotNullOrEmptyString(owner, "owner");
            Ensure.ArgumentNotNullOrEmptyString(name, "name");
            Ensure.ArgumentNotNull(options, "options");

            return _connection.GetAndFlattenAllPages<Notification>(ApiUrls.Notifications(owner, name), options);
        }

        /// <summary>
        /// Retrieves all of the <see cref="Notification"/>s for the current user specific to the specified repository.
        /// </summary>
        /// <param name="repositoryId">The ID of the repository.</param>
        /// <param name="options">Options for changing the API response</param>
        /// <exception cref="AuthorizationException">Thrown if the client is not authenticated.</exception>
        public IObservable<Notification> GetAllForRepository(int repositoryId, ApiOptions options)
        {
            Ensure.ArgumentNotNull(options, "options");

            return _connection.GetAndFlattenAllPages<Notification>(ApiUrls.Notifications(repositoryId), options);
        }

        /// <summary>
        /// Retrieves all of the <see cref="Notification"/>s for the current user.
        /// </summary>
        /// <param name="request">Specifies the parameters to filter notifications by</param>
        /// <exception cref="AuthorizationException">Thrown if the client is not authenticated.</exception>
        public IObservable<Notification> GetAllForCurrent(NotificationsRequest request)
        {
            Ensure.ArgumentNotNull(request, "request");

            return GetAllForCurrent(request, ApiOptions.None);
        }

        /// <summary>
        /// Retrieves all of the <see cref="Notification"/>s for the current user.
        /// </summary>
        /// <param name="request">Specifies the parameters to filter notifications by</param>
        /// <param name="options">Options for changing the API response</param>
        /// <exception cref="AuthorizationException">Thrown if the client is not authenticated.</exception>
        public IObservable<Notification> GetAllForCurrent(NotificationsRequest request, ApiOptions options)
        {
            Ensure.ArgumentNotNull(request, "request");
            Ensure.ArgumentNotNull(options, "options");

            return _connection.GetAndFlattenAllPages<Notification>(ApiUrls.Notifications(), request.ToParametersDictionary(), options);
        }

        /// <summary>
        /// Retrieves all of the <see cref="Notification"/>s for the current user specific to the specified repository.
        /// </summary>
        /// <param name="owner">The owner of the repository.</param>
        /// <param name="name">The name of the repository.</param>
        /// <param name="request">Specifies the parameters to filter notifications by</param>
        /// <exception cref="AuthorizationException">Thrown if the client is not authenticated.</exception>
        public IObservable<Notification> GetAllForRepository(string owner, string name, NotificationsRequest request)
        {
            Ensure.ArgumentNotNullOrEmptyString(owner, "owner");
            Ensure.ArgumentNotNullOrEmptyString(name, "name");
            Ensure.ArgumentNotNull(request, "request");

            return GetAllForRepository(owner, name, request, ApiOptions.None);
        }

        /// <summary>
        /// Retrieves all of the <see cref="Notification"/>s for the current user specific to the specified repository.
        /// </summary>
        /// <param name="repositoryId">The ID of the repository.</param>
        /// <param name="request">Specifies the parameters to filter notifications by</param>
        /// <exception cref="AuthorizationException">Thrown if the client is not authenticated.</exception>
        public IObservable<Notification> GetAllForRepository(int repositoryId, NotificationsRequest request)
        {
            Ensure.ArgumentNotNull(request, "request");

            return GetAllForRepository(repositoryId, request, ApiOptions.None);
        }

        /// <summary>
        /// Retrieves all of the <see cref="Notification"/>s for the current user specific to the specified repository.
        /// </summary>
        /// <param name="owner">The owner of the repository.</param>
        /// <param name="name">The name of the repository.</param>
        /// <param name="request">Specifies the parameters to filter notifications by</param>
        /// <param name="options">Options for changing the API response</param>
        /// <exception cref="AuthorizationException">Thrown if the client is not authenticated.</exception>
        public IObservable<Notification> GetAllForRepository(string owner, string name, NotificationsRequest request, ApiOptions options)
        {
            Ensure.ArgumentNotNullOrEmptyString(owner, "owner");
            Ensure.ArgumentNotNullOrEmptyString(name, "name");
            Ensure.ArgumentNotNull(request, "request");
            Ensure.ArgumentNotNull(options, "options");

            return _connection.GetAndFlattenAllPages<Notification>(ApiUrls.Notifications(owner, name), request.ToParametersDictionary(), options);
        }

        /// <summary>
        /// Retrieves all of the <see cref="Notification"/>s for the current user specific to the specified repository.
        /// </summary>
        /// <param name="repositoryId">The ID of the repository.</param>
        /// <param name="request">Specifies the parameters to filter notifications by</param>
        /// <param name="options">Options for changing the API response</param>
        /// <exception cref="AuthorizationException">Thrown if the client is not authenticated.</exception>
        public IObservable<Notification> GetAllForRepository(int repositoryId, NotificationsRequest request, ApiOptions options)
        {
            Ensure.ArgumentNotNull(request, "request");
            Ensure.ArgumentNotNull(options, "options");

            return _connection.GetAndFlattenAllPages<Notification>(ApiUrls.Notifications(repositoryId), request.ToParametersDictionary(), options);
        }

        /// <summary>
        /// Marks all notifications as read.
        /// </summary>
        /// <remarks>http://developer.github.com/v3/activity/notifications/#mark-as-read</remarks>
        public IObservable<Unit> MarkAsRead()
        {
            return _notificationsClient.MarkAsRead().ToObservable();
        }

        /// <summary>
        /// Marks all notifications as read.
        /// </summary>
        /// <param name="markAsReadRequest">The <see cref="MarkAsReadRequest"/> parameter which specifies which notifications to mark.</param>
        /// <remarks>http://developer.github.com/v3/activity/notifications/#mark-as-read</remarks>
        public IObservable<Unit> MarkAsRead(MarkAsReadRequest markAsReadRequest)
        {
            Ensure.ArgumentNotNull(markAsReadRequest, "markAsReadRequest");

            return _notificationsClient.MarkAsRead(markAsReadRequest).ToObservable();
        }

        /// <summary>
        /// Marks the notifications for a given repository as read.
        /// </summary>
        /// <param name="owner">The owner of the repository</param>
        /// <param name="name">The name of the repository</param>
        /// <remarks>http://developer.github.com/v3/activity/notifications/#mark-notifications-as-read-in-a-repository</remarks>
        public IObservable<Unit> MarkAsReadForRepository(string owner, string name)
        {
            Ensure.ArgumentNotNullOrEmptyString(owner, "owner");
            Ensure.ArgumentNotNullOrEmptyString(name, "name");

            return _notificationsClient.MarkAsReadForRepository(owner, name).ToObservable();
        }

        /// <summary>
        /// Marks the notifications for a given repository as read.
        /// </summary>
        /// <param name="repositoryId">The ID of the repository</param>
        /// <remarks>http://developer.github.com/v3/activity/notifications/#mark-notifications-as-read-in-a-repository</remarks>
        public IObservable<Unit> MarkAsReadForRepository(int repositoryId)
        {
            return _notificationsClient.MarkAsReadForRepository(repositoryId).ToObservable();
        }

        /// <summary>
        /// Marks the notifications for a given repository as read.
        /// </summary>
        /// <param name="owner">The owner of the repository</param>
        /// <param name="name">The name of the repository</param>
        /// <param name="markAsReadRequest">The <see cref="MarkAsReadRequest"/> parameter which specifies which notifications to mark.</param>
        /// <remarks>http://developer.github.com/v3/activity/notifications/#mark-notifications-as-read-in-a-repository</remarks>
        public IObservable<Unit> MarkAsReadForRepository(string owner, string name, MarkAsReadRequest markAsReadRequest)
        {
            Ensure.ArgumentNotNullOrEmptyString(owner, "owner");
            Ensure.ArgumentNotNullOrEmptyString(name, "name");
            Ensure.ArgumentNotNull(markAsReadRequest, "markAsReadRequest");

            return _notificationsClient.MarkAsReadForRepository(owner, name, markAsReadRequest).ToObservable();
        }

        /// <summary>
        /// Marks the notifications for a given repository as read.
        /// </summary>
        /// <param name="repositoryId">The ID of the repository</param>
        /// <param name="markAsReadRequest">The <see cref="MarkAsReadRequest"/> parameter which specifies which notifications to mark.</param>
        /// <remarks>http://developer.github.com/v3/activity/notifications/#mark-notifications-as-read-in-a-repository</remarks>
        public IObservable<Unit> MarkAsReadForRepository(int repositoryId, MarkAsReadRequest markAsReadRequest)
        {
            Ensure.ArgumentNotNull(markAsReadRequest, "markAsReadRequest");

            return _notificationsClient.MarkAsReadForRepository(repositoryId, markAsReadRequest).ToObservable();
        }

        /// <summary>
        /// Retrives a single <see cref="Notification"/> by Id.
        /// </summary>
        /// <param name="id">The Id of the notification to retrieve.</param>
        /// <remarks>http://developer.github.com/v3/activity/notifications/#view-a-single-thread</remarks>
        public IObservable<Notification> Get(int id)
        {
            return _notificationsClient.Get(id).ToObservable();
        }

        /// <summary>
        /// Marks a single notification as read.
        /// </summary>
        /// <param name="id">The id of the notification.</param>
        /// <remarks>http://developer.github.com/v3/activity/notifications/#mark-a-thread-as-read</remarks>
        public IObservable<Unit> MarkAsRead(int id)
        {
            return _notificationsClient.MarkAsRead(id).ToObservable();
        }

        /// <summary>
        /// Retrives a <see cref="ThreadSubscription"/> for the provided thread id.
        /// </summary>
        /// <param name="id">The Id of the thread to retrieve subscription status.</param>
        /// <remarks>http://developer.github.com/v3/activity/notifications/#get-a-thread-subscription</remarks>
        public IObservable<ThreadSubscription> GetThreadSubscription(int id)
        {
            return _notificationsClient.GetThreadSubscription(id).ToObservable();
        }

        /// <summary>
        /// Sets the authenticated user's subscription settings for a given thread.
        /// </summary>
        /// <param name="id">The Id of the thread to update.</param>
        /// <param name="threadSubscription">The subscription parameters to set.</param>
        /// <remarks>http://developer.github.com/v3/activity/notifications/#set-a-thread-subscription</remarks>
        public IObservable<ThreadSubscription> SetThreadSubscription(int id, NewThreadSubscription threadSubscription)
        {
            Ensure.ArgumentNotNull(threadSubscription, "threadSubscription");

            return _notificationsClient.SetThreadSubscription(id, threadSubscription).ToObservable();
        }

        /// <summary>
        /// Deletes the authenticated user's subscription to a given thread.
        /// </summary>
        /// <param name="id">The Id of the thread to delete subscription from.</param>
        /// <remarks>http://developer.github.com/v3/activity/notifications/#delete-a-thread-subscription</remarks>
        public IObservable<Unit> DeleteThreadSubscription(int id)
        {
            return _notificationsClient.DeleteThreadSubscription(id).ToObservable();
        }
    }
}
