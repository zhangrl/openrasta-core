﻿using System;
using System.Threading.Tasks;
using OpenRasta.Web;

namespace OpenRasta.Pipeline
{
  public abstract class AbstractContributorMiddleware : IPipelineMiddlewareFactory, IPipelineMiddleware
  {
    protected IPipelineMiddleware Next { get; private set; }
    protected Func<ICommunicationContext, Task<PipelineContinuation>> Contributor { get; }
    public abstract Task Invoke(ICommunicationContext env);

    protected AbstractContributorMiddleware(Func<ICommunicationContext, Task<PipelineContinuation>> singleTapContributor)
    {
      if (singleTapContributor == null)
        throw new ArgumentNullException(nameof(singleTapContributor));
      Contributor = singleTapContributor;
    }

    public virtual IPipelineMiddleware Compose(IPipelineMiddleware next)
    {
      Next = next;
      return this;
    }
  }
}
