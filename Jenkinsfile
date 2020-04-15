pipeline {
    agent any
    environment {
        ver = "1.0.4.${env.BUILD_NUMBER}"
    }
    stages {
        stage('Build') {
            steps {
                echo '''


                ----------------------------------------------'''
                echo "Building version ${ver}"
                sh label:'Restore Packages', script:'dotnet restore Xumiga.DataGenerators.sln'
                sh label:'Build', script:"dotnet build Xumiga.DataGenerators.sln -c Release /p:Platform='Any CPU' /p:ProductVersion=${ver} /p:Version=${ver} /p:FileVersion=${ver}"
            } 
        }
        stage('Test') {
            steps {
                echo '''


                ----------------------------------------------'''
                echo "Testing binaries ${ver}"
                sh label:'Restore Packages', script:'dotnet restore Xumiga.DataGenerators.tests/Xumiga.DataGenerators.tests.csproj'
                sh label:'Run Tests', script:"dotnet test Xumiga.DataGenerators.tests/Xumiga.DataGenerators.tests.csproj --logger 'trx;LogFileName=${env.WORKSPACE}/TestsReport-${ver}.trx'"
            }
        }
    }
    post {
        always {
            archiveArtifacts artifacts: '**/Release/**/Xumiga.DataGenerators.*.nupkg', onlyIfSuccessful: true
            mstest keepLongStdio: true
            cleanWs deleteDirs: true
        }
    }

}