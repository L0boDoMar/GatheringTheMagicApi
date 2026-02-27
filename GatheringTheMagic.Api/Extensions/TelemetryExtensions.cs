using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace GatheringTheMagic.Api.Extensions
{
    public static class TelemetryExtensions
    {
        public static void ConfigureTelemetry(this IServiceCollection services)
        {

            // Define o nome do serviço para aparecer no Jaeger/Prometheus
            var serviceName = "GatheringTheMagicApi";

            services.AddOpenTelemetry()
                .ConfigureResource(resource => resource.AddService(serviceName))
            .WithTracing(tracing =>
            {
                tracing
                    .AddAspNetCoreInstrumentation() // Captura requisições de entrada
                    .AddHttpClientInstrumentation() // Captura requisições de saída (ex: chamadas a outras APIs)
                    .AddOtlpExporter(opts =>
                    {
                        opts.Endpoint = new Uri("http://localhost:4317"); // Endpoint do OTel Collector
                        opts.Protocol = OpenTelemetry.Exporter.OtlpExportProtocol.Grpc; //Define o protocolo com GPRC 
                    });
            })
            .WithMetrics(metrics =>
            {
                metrics
                    .AddAspNetCoreInstrumentation()
                    .AddHttpClientInstrumentation()
                    .AddRuntimeInstrumentation() // Métricas do runtime do .NET (CPU, Memória, Garbage Collector)
                    .AddOtlpExporter(opts =>
                    {
                        opts.Endpoint = new Uri("http://localhost:4317"); // Endpoint do OTel Collector
                        opts.Protocol = OpenTelemetry.Exporter.OtlpExportProtocol.Grpc;
                    }).AddPrometheusExporter(); ;

            });
        }
    }
}
