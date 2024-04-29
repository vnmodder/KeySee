using Squirrel.Infrastructure.Databases.Common.TableColumnAudit;

namespace Squirrel.Infrastructure.Databases.Common.BaseEntityModels
{
    public abstract class BaseEntity
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Gets or sets the insert user identifier.
        /// </summary>
        public int? InsertUserId { get; set; }

        /// <summary>
        /// Gets or sets the insert date.
        /// </summary>
        [ItemId("0000")]
        public DateTime? InsertDate { get; set; }

        /// <summary>
        /// Gets or sets the update user identifier.
        /// </summary>
        public int? UpdateUserId { get; set; }

        /// <summary>
        /// Gets or sets the update date.
        /// </summary>
        [ItemId("0000")]
        public DateTime? UpdateDate { get; set; }

        /// <summary>
        /// Gets or sets the delete user identifier.
        /// </summary>
        public int? DeleteUserId { get; set; } = null;

        /// <summary>
        /// Gets or sets the delete date.
        /// </summary>
        [ItemId("0000")]
        public DateTime? DeleteDate { get; set; } = null;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is deleted.
        /// </summary>
        public bool? IsDeleted { get; set; } = false;
    }
}
