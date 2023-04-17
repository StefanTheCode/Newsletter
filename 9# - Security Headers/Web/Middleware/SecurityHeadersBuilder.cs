namespace Web.Middleware;

public class SecurityHeadersBuilder
{
    private readonly SecurityHeadersPolicy _policy = new SecurityHeadersPolicy();

    public SecurityHeadersBuilder AddDefaultSecurePolicy()
    {
        RemoveHeader("X-Powered-By");
        RemoveHeader("X-AspNet-Version");
        RemoveHeader("X-AspNetMvc-Version");
        RemoveHeader("Server");
        RemoveHeader("X-Forwarded-Host");

        AddFrameOptionsSameOrigin();
        AddXssProtection();
        AddXContentTypeOptions();
        AddReferrerPolicy();
        AddContentSecurityPolicy();
        AddPermissionsPolicy();
        AddExpectCT();

        return this;
    }

    public SecurityHeadersBuilder AddFrameOptionsSameOrigin()
    {
        _policy.SetHeaders["X-Frame-Options"] = "SAMEORIGIN";
        return this;
    }

    public SecurityHeadersBuilder AddExpectCT()
    {
        _policy.SetHeaders["Expect-CT"] = "max-age=2592000";
        return this;
    }

    public SecurityHeadersBuilder AddPermissionsPolicy()
    {
        _policy.SetHeaders["Permissions-Policy"] = "accelerometer=(), camera=(), geolocation=(), gyroscope=(), magnetometer=(), microphone=(), payment=(), usb=()";

        //Feature-Policy is an older header that is now deprecated
        _policy.SetHeaders["Feature-Policy"] = "accelerometer=(), camera=(), geolocation=(), gyroscope=(), magnetometer=(), microphone=(), payment=(), usb=()";

        return this;
    }

    //Not standard
    public SecurityHeadersBuilder AddXssProtection()
    {
        _policy.SetHeaders["X-Xss-Protection"] = "1; mode=block";
        return this;
    }

    public SecurityHeadersBuilder AddXContentTypeOptions()
    {
        _policy.SetHeaders["X-Content-Type-Options"] = "nosniff";
        return this;
    }

    public SecurityHeadersBuilder AddReferrerPolicy()
    {
        _policy.SetHeaders["Referrer-Policy"] = "no-referrer";
        return this;
    }

    //Can be added in this way also
    public SecurityHeadersBuilder AddStrictTransportSecurity()
    {
        _policy.SetHeaders["Strict-Transport-Security"] = "max-age=31536000;includeSubDomains;preload";
        return this;
    }

    public SecurityHeadersBuilder AddContentSecurityPolicy()
    {
        //_policy.SetHeaders["Content-Security-Policy"] = "default-src 'self' 'unsafe-inline'; connect-src 'self' ws:; style-src 'self' 'unsafe-inline'";
        _policy.SetHeaders["Content-Security-Policy"] = "default-src 'self'; script-src 'self' https://cdnjs.cloudflare.com";
        return this;
    }

    public SecurityHeadersBuilder AddCustomHeader(string header, string value)
    {
        _policy.SetHeaders[header] = value;
        return this;
    }

    public SecurityHeadersBuilder RemoveHeader(string header)
    {
        _policy.RemoveHeaders.Add(header);
        return this;
    }

    public SecurityHeadersPolicy Build()
    {
        return _policy;
    }
}