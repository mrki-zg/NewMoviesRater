// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: movies.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace MoviesService {
  public static partial class Movies
  {
    static readonly string __ServiceName = "movies.Movies";

    static readonly grpc::Marshaller<global::MoviesService.UploadMoviesRequest> __Marshaller_movies_UploadMoviesRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::MoviesService.UploadMoviesRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Google.Protobuf.WellKnownTypes.Empty> __Marshaller_google_protobuf_Empty = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Google.Protobuf.WellKnownTypes.Empty.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::MoviesService.Movie> __Marshaller_movies_Movie = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::MoviesService.Movie.Parser.ParseFrom);

    static readonly grpc::Method<global::MoviesService.UploadMoviesRequest, global::Google.Protobuf.WellKnownTypes.Empty> __Method_UploadMovies = new grpc::Method<global::MoviesService.UploadMoviesRequest, global::Google.Protobuf.WellKnownTypes.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "UploadMovies",
        __Marshaller_movies_UploadMoviesRequest,
        __Marshaller_google_protobuf_Empty);

    static readonly grpc::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::MoviesService.Movie> __Method_GetMoviesStream = new grpc::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::MoviesService.Movie>(
        grpc::MethodType.ServerStreaming,
        __ServiceName,
        "GetMoviesStream",
        __Marshaller_google_protobuf_Empty,
        __Marshaller_movies_Movie);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::MoviesService.MoviesReflection.Descriptor.Services[0]; }
    }

    /// <summary>Client for Movies</summary>
    public partial class MoviesClient : grpc::ClientBase<MoviesClient>
    {
      /// <summary>Creates a new client for Movies</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public MoviesClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for Movies that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public MoviesClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected MoviesClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected MoviesClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual global::Google.Protobuf.WellKnownTypes.Empty UploadMovies(global::MoviesService.UploadMoviesRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return UploadMovies(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::Google.Protobuf.WellKnownTypes.Empty UploadMovies(global::MoviesService.UploadMoviesRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_UploadMovies, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::Google.Protobuf.WellKnownTypes.Empty> UploadMoviesAsync(global::MoviesService.UploadMoviesRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return UploadMoviesAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::Google.Protobuf.WellKnownTypes.Empty> UploadMoviesAsync(global::MoviesService.UploadMoviesRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_UploadMovies, null, options, request);
      }
      public virtual grpc::AsyncServerStreamingCall<global::MoviesService.Movie> GetMoviesStream(global::Google.Protobuf.WellKnownTypes.Empty request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetMoviesStream(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncServerStreamingCall<global::MoviesService.Movie> GetMoviesStream(global::Google.Protobuf.WellKnownTypes.Empty request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncServerStreamingCall(__Method_GetMoviesStream, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override MoviesClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new MoviesClient(configuration);
      }
    }

  }
}
#endregion