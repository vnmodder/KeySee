﻿using MediatR;

namespace Squirrel.Application.Common.CQRS
{
    public abstract class BaseRequest<TResponse> : IRequest<TResponse> where TResponse : class
    {
    }

    public abstract class BaseRequest : IRequest<Unit>
    {
    }
}
