workflow "CI/CD" {
  resolves = ["Setup Dotnet for use with actions"]
  on = "check_run"
}

action "Setup Dotnet for use with actions" {
  uses = "actions/setup-dotnet@a2db70294c800f14593a400f4a1dc16ff5a73a36"
}
