using System.Collections.Immutable;
using System.Text;

namespace EventHub.Business.Reporting;

public abstract class ReportTemplate<T>
{
    public void Generate(IEnumerable<T> data)
    {
        WriteHeader();
        WriteBody(data.ToImmutableList());
        WriteFooter();

        GenerateSpecificReportFormat();
    }

    protected StringBuilder Report { get; } = new();

    protected abstract void WriteHeader();

    protected abstract void WriteBody(ImmutableList<T> units);

    protected abstract void WriteFooter();

    protected abstract void GenerateSpecificReportFormat();
}