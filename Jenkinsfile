pipeline {
    agent any
    stages {
        stage('Checkout') {
            steps {
                echo 'Checking out code..'
                deleteDir()
                checkout scm
            }
        }
        stage('Build') {
            steps {
                echo 'Building..'
                sh("dotnet restore Xumiga.DataGenerators.sln")
                sh("dotnet build Xumiga.DataGenerators.sln /p:Configuration=Release /p:Platform=\"Any CPU\" /p:ProductVersion=1.0.4.${env.BUILD_NUMBER}")
            }
        }
        stage('Test') {
            steps {
                echo 'Testing..'
                sh("dotnet restore Xumiga.DataGenerators.tests/Xumiga.DataGenerators.tests.csproj")
                sh("dotnet test Xumiga.DataGenerators.tests/Xumiga.DataGenerators.tests.csproj --logger 'trx;LogFileName=${env.WORKSPACE}/TestsReport-1.0.4.${env.BUILD_NUMBER}.trx'")
                mstest keepLongStdio: true
            }
        }
        stage('Archive atricacts') {
            steps {
                echo 'Deploying....'
            }
        }
    }
    post {
        always {
            archiveArtifacts artifacts: '**/Xumiga.DataGenerators.dll', onlyIfSuccessful: true
            archiveArtifacts artifacts: '**/*.trx', onlyIfSuccessful: true
        }
    }

}