FROM mcr.microsoft.com/dotnet/core/sdk:2.2

# Install Mono
RUN apt update && \
    apt install -y apt-transport-https dirmngr gnupg ca-certificates && \
    apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF && \
    echo "deb https://download.mono-project.com/repo/debian stable-stretch main" | tee /etc/apt/sources.list.d/mono-official-stable.list && \
    apt update && \
    apt install -y mono-devel && \
    rm -rf /var/lib/apt/lists/*

# Install nuget executable
RUN curl -o /usr/local/bin/nuget.exe https://dist.nuget.org/win-x86-commandline/latest/nuget.exe && \
    echo 'alias nuget="mono /usr/local/bin/nuget.exe"' >> ~/.bashrc && \
    echo -e '#!/bin/bash\nmono /usr/local/bin/nuget.exe "$@"' > /usr/local/bin/nuget && chmod u+x /usr/local/bin/nuget
