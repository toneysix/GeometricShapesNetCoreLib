
if ! type "dotnet" > /dev/null; then
	echo "Compiler isn't detected, please install dotnet manually before run build.sh"
fi

dotnet --version
origPath=$PATH
binDir="$PWD/bin/"

export DOTNET_HOME="$DOTNET_INSTALL_DIR/cli"
export PATH="$DOTNET_HOME/bin:$PATH"

# Prepare
echo "Restoring all projects..."
dotnet restore -v Minimal
echo "Done restoring."

# Build
echo "Building library..."
for d in src/*/*.csproj;
do
        dotnet build "$d" -o $binDir -c Release --no-restore
done
echo "Done building library."

# Test
for d in tests/*/*.csproj; do 
    echo "Testing $d"
    dotnet test "$d" -c Release --no-restore
done
echo "Build Complete."

export PATH=$origPath

