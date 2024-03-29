﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BusinessLayer.Utilities.Messages
{
    public static class Messages
    {
        public static string AuthorizationDenied = "Authorization Denied";
        public static string CategoryAdded = "Category is added";
        public static string CategoryNotAdded = "Category could not be added";
        public static string CategoryInvalid = "Category is invalid";
        public static string CategoryDeleted = "Category is deleted";
        public static string CategoryNotDeleted = "Category could not be deleted";
        public static string CategoryListed = "Categories are listed";
        public static string CategoryUpdated = "Category is updated";
        public static string CategoryNotUpdated = "Category could not be updated";
        public static string ProductInvalid = "Product is invalid";
        public static string ProductDeleted = "Product is deleted";
        public static string ProductNotDeleted = "Product could not be deleted";
        public static string CategoryNameAlreadyExists = "Category name already exist";
        public static string LoginWarning = "Wrong Username or Password.";
        public static string SuccesfulLogin = "Wrong Username or Password.";
        public static string UserRegistered = "Wrong Username or Password.";
        public static string TokenGenerated = "Token Generated";

        public static string ProductAdded = "Product is Added.";

        public static string ProductUpdated = "Product is updated.";

        public static string NotProductOwner = "You do not own this product.";

        public static string UserInvalid = "User invalid.";

        public static string ProductsListed = "Products listed.";

        public static string ProductNotSaled = "Product is not on sale.";

        public static string OfferAccepted = "Offer is accepted.";

        public static string OfferInvalid = "Offer is invalid.";

        public static string OfferDeleted = "Offer is deleted.";
        public static string OfferUpdated = "Offer updated.";
        public static string OfferApproved = "Offer is approved.";
        public static string NotOfferOwner = "You do not have this offer record. Please check offer id.";
        public static string OffersListed = "Offers are listed.";
        public static string ProductSold = "Product is sold.";
        public static string OfferCannotWitdrawn = "Offer has been already approved. You cannot withdraw your offer back.";
        public static string OfferWithdrawn = "Offer is withdrawn.";
        public static string NoUserOffer = "You do not have any offer record";
        public static string NoUserProductOffer = "There is no any offer to your product.";
        public static string EmailRequired = "Email is required.";
        public static string PasswordRequired = "Password is required.";

        public static string EmailAlreadyExists = "Email already exist";

        public static string OwnProduct = "This is your own product. You cannot make an offer.";

        public static string NotRelevantOffer = "This offer is not related with your product.";

        public static string OfferAlreadyApproved = "Offer already approved";

        public static string BlogListed = "Blogs listed";

        public static string CommentListed = "Comments listed";

        public static string AuthorAdded = "Author added";

        public static string NewsLetterAdded = "NewsLetter added";

        public static string CommentAdded = "Comment added";

        public static string AboutListed = "About listed";

        public static string ContactAdded = "Contact added";

        public static string BlogAdded = "Blog added";

        public static string BlogDeleted { get; internal set; }
        public static string BlogUpdated { get; internal set; }
        public static string AuthorListed { get; internal set; }
        public static string AuthorUpdated { get; internal set; }
    }
}
