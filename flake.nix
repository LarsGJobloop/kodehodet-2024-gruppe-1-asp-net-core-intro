{
  description = "A very basic flake";

  inputs = {
    nixpkgs.url = "github:nixos/nixpkgs?ref=nixos-unstable";
  };

  outputs =
    { self, nixpkgs }:
    let
      allSupportedSystems = [
        "x86_64-linux"
        "aarch64-linux"
        "x86_64-darwin"
        "aarch64-darwin"
      ];
      forEachSupportedSystems = nixpkgs.lib.genAttrs allSupportedSystems;
    in
    {
      devShells = forEachSupportedSystems (
        system:
        let
          pkgs = import nixpkgs { inherit system; };
        in
        {
          default = pkgs.mkShell {
            # Project dependencies
            packages = [
              pkgs.azure-cli # For communicating with Azure through the terminal
              pkgs.dotnetCorePackages.sdk_8_0 # Set of tools for developing a C# .NET application
              pkgs.omnisharp-roslyn # Langauge Sever for C# and .NET
            ];

            # Environment Variables
            # Expose the exact path to the Dotnet binaries
            DOTNET_ROOT = builtins.toString pkgs.dotnetCorePackages.sdk_8_0;
            DOTNET_BIN = "${pkgs.dotnetCorePackages.sdk_8_0}/bin/dotnet";
          };
        }
      );
    };
}